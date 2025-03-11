using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public partial class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public float attackedSpeedX;
    public float attackedSpeedY;
    public float maxHealth;
    public float currHealth;
    public float damage;

    public static GameObject mHero;

    public bool setY;
    public bool noRotate;
    public float dashDis;
    public Animator anim=null;
    public float upSpeed=0f;
    public bool idleStatus=false;
    public float speed;
    public float skySpeed;
    //public Vector3 initPos;
    public float jumpSpeed;
    public float againJumpSpeed;
    public float jumpFrom;
    public float scale;
    public bool canJump=true;
    public bool duringJump=false;
    public float dashCoolDown;
    bool isGround;
    public Vector3 dashPos;
    private float lastDashAt;
    public Vector3 dashStartPos;
    public int maxJumpTimes;
    public AnimatorStateInfo info;
    public int leftJumpTimes=2;

    private Vector3 p;
    private Vector3 s;
    private Quaternion r;
    private Rigidbody2D myRigid;
    private BoxCollider2D myfeet;
    private PolygonCollider2D attackCollider;
    public float timeBeforeAttack;
    public float timeAfterAttack;
    public float originA;
    public bool gamemode;
    public SpriteRenderer sp;
    public bool attacked;
    void Start()
    {
        currHealth=maxHealth;
        leftJumpTimes=maxJumpTimes;
        attackCollider=GetComponent<PolygonCollider2D>();
        myRigid=GetComponent<Rigidbody2D>();
        myfeet=GetComponent<BoxCollider2D>();
        //transform.localPosition=initPos;
        transform.localScale=new Vector3(scale,scale,0);
        anim=GetComponent<Animator>();
        gm=GameManager.mGM;
        attackCollider.enabled=false;
        sp=GetComponent<SpriteRenderer>();
        originA=sp.color.a;
        attacked=false;

        Debug.Assert(gm!=null);
        Debug.Assert(sp!=null);

    }
    // Update is called once per frame
    void Update()
    {
        if(gamemode)
        {
            isGround=touchingGround();
            p=transform.localPosition;
            s=transform.localScale;
            r=transform.localRotation;
            action();
            skill();
            //Debug.Log("action done");
            r.z=0;
            transform.localPosition=p;
            //Debug.Log($"final update position: p.y:{p.x}");
            transform.localScale=s;
            transform.localRotation=r;
            if(currHealth<=0)
            {
                die();
            }
            if(attacked==false)
            {
                Color color=sp.color;
                color.a=originA;
                sp.color=color;
            }
            else
            {
                Color color =sp.color;
                color.a*=originA*0.3f;
                sp.color=color;
            }
        }
        else
        {
            sp.color=Color.red;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Player: onTriggerEnter, other has BossAttacked is :{other.gameObject.GetComponent<Boss1>()!=null}");
        other.gameObject.GetComponent<Boss1>().takeDamage(damage);
    }
    //     void OnCollisionEnter2D(Collision2D other)
    //{
        //Debug.Log("Player onCollisionEnter");
        //if(other.gameObject.name=="boss")takeDamage(10f);
        //else if(other.gameObject.CompareTag("EnemyAttack"))
        //{
            //takeDamage(6f);
            //Destroy(other.gameObject);
        //}
    //}

    public void takeDamage(float damage)
    {
        currHealth-=damage;
        Boss1 b=gm.Boss.GetComponent<Boss1>();
        Vector2 knockbackforce;
        if(b.transform.localPosition.x>p.x)
        {
            knockbackforce=new Vector2(-attackedSpeedX,attackedSpeedY);
        }
        else
        {
            knockbackforce=new Vector2(attackedSpeedX,attackedSpeedY);
        }
        Debug.Log("player attacked");
        attacked=true;
        myRigid.AddForce(knockbackforce,ForceMode2D.Impulse);
        StartCoroutine(HitFlashEffect());
    }

    private IEnumerator HitFlashEffect()
    {
        attacked=true;
        yield return new WaitForSeconds(0.1f);
        attacked=false;
    }
}

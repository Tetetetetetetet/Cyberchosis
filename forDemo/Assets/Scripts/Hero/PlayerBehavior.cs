using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public partial class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    //basis status
    public float attackedSpeedX;
    public float attackedSpeedY;
    public float maxHealth;
    public float currHealth;
    public float damage;
    public float remoteDamage;
    public float swordCooldown;
    public float fireCooldown;
    public float minX;
    public float maxX;

    // About Dash
    //public float dashDis;
    //public float dashCoolDown;
    //public Vector3 dashPos;
    //private float lastDashAt;
    //public Vector3 dashStartPos;
    //testing
    //public bool setY;
    //public bool noRotate;
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
    bool isGround;
    public float lastRollAt;
    public float rollCooldown;
    public float rollSpeed;
    public float rollDuringTime;
    public int maxJumpTimes;
    public AnimatorStateInfo info;
    public int leftJumpTimes=2;

    private Vector3 p;
    public Animator anim=null;
    private Vector3 s;
    private Quaternion r;
    private Rigidbody2D myRigid;
    public BoxCollider2D myfeet;
    public float timeBeforeAttack;
    public float timeAfterAttack;
    public float originA;
    public bool gamemode;
    public SpriteRenderer sp;
    public bool attacked;
    public GameObject mySword; // 可能需要手动拖
    public GameManager gm;
    public Boss1 b;
    public static GameObject mHero;
    public bool canSkill1,canSkill2,canSkill3;
    private float lastSwordAttackAt;
    private float lastFireAt;
    void Start()
    {
        currHealth=maxHealth;
        leftJumpTimes=maxJumpTimes;
        myRigid=gameObject.GetComponent<Rigidbody2D>();
        myfeet=gameObject.GetComponent<BoxCollider2D>();
        //transform.localPosition=initPos;
        transform.localScale=new Vector3(scale,scale,0);
        anim=GetComponent<Animator>();
        gm=GameManager.mGM;
        sp=GetComponent<SpriteRenderer>();
        originA=sp.color.a;
        attacked=false;
        gamemode=true;
        mySword=util.findGameObject("HeroSwordAttack");
        lastFireAt=-10;
        lastRollAt=-10;
        lastSwordAttackAt=-10;

        //key mapping
        KeyJump=KeyCode.W;
        KeyFire=KeyCode.Mouse1;
        KeySword=KeyCode.Mouse0;
        KeyPlaceMagic=KeyCode.V;
        KeyThrow=KeyCode.R;
        KeySit=KeyCode.S;
        KeyTurnMagic=KeyCode.E;
        KeyCrouch=KeyCode.X;
        KeyCombo=KeyCode.Mouse4;
        KeyRoll=KeyCode.LeftAlt;


        Debug.Assert(gm!=null);
        Debug.Assert(sp!=null);
        Debug.Assert(mySword!=null);

    }
    // Update is called once per frame
    void Update()
    {
        checkChangeScene();
        isGround = touchingGround();
        p = transform.localPosition;
        s = transform.localScale;
        r = transform.localRotation;
        action();
        skill();
        //Debug.Log("action done");
        r.z = 0;
        if (currHealth <= 0)
        {
            die();
        }
        if (attacked == false)
        {
            Color color = sp.color;
            color.a = originA;
            sp.color = color;
        }
        else
        {
            Color color = sp.color;
            color.a *= originA * 0.3f;
            sp.color = color;
        }
        if(p.x>maxX)p.x=maxX;
        if(p.x<minX)p.x=minX;   
        transform.localPosition = p;
        //Debug.Log($"final update position: p.y:{p.x}");
        transform.localScale = s;
        transform.localRotation = r;
    }
    void checkChangeScene()
        {
            if (gamemode)
            {
                if (gm.sceneId == 1)
                {
                    if (transform.localPosition.x > 15)
                    {
                        gm.changeScene(2);
                    }
                    if (transform.localPosition.x < -18)
                    {
                        SceneManager.LoadScene("TransitionScene");
                    }
                }
                if (gm.sceneId == 2)
                {
                    if (transform.localPosition.x < -18)
                    {
                        gm.changeScene(2);
                    }
                }
        }
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
        //if(gm.isBoss)Debug.Log($"Player: onTriggerEnter, other has BossAttacked is :{other.gameObject.GetComponent<Boss1>()!=null}");
        //if(gm.isBoss&&other.gameObject.CompareTag("Boss"))other.gameObject.GetComponent<Boss1>().takeDamage(damage);
        //GameObject enemy=other.gameObject;
        //Debug.Log($"player: enter trigger");
    //}
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
        if(anim.GetBool("isRoll")==false)
        {
            Debug.Log($"Hero get damage: {damage}");
            currHealth -= damage;
            Vector2 knockbackforce;
            if (gm.isBoss)
            {
                b = gm.Boss.GetComponent<Boss1>();
                if (b.transform.localPosition.x > p.x)
                {
                    knockbackforce = new Vector2(-attackedSpeedX, attackedSpeedY);
                }
                else
                {
                    knockbackforce = new Vector2(attackedSpeedX, attackedSpeedY);
                }
                myRigid.AddForce(knockbackforce, ForceMode2D.Impulse);
            }
            Debug.Log("player attacked");
            attacked = true;
            StartCoroutine(HitFlashEffect());
        }
        else
        {
            Debug.Log("hero attacked while rolling");
        }
    }

    private IEnumerator HitFlashEffect()
    {
        attacked=true;
        yield return new WaitForSeconds(0.1f);
        attacked=false;
    }
}

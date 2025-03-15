using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    // necessary parameters
    public GameObject attackob;// 手动挂载攻击武器
    public BossAttack ba;
    public float maxHealth;
    public float currHealth;
    public float walkSpeed;
    public float minDis;
    public float jumpSpeed;
    public float scale;
    public float attackRange;
    public float moveSpeed;
    public float attackCoolDown;
    public float attackLastTime;
    public float gravityScale;    
    //may use
    // for watching
    public bool isAttacking;
    public bool debugflag;
    public GameObject mHero; //接口：自动接Player GameObject
    public Rigidbody2D myRigid; //auto
    public BoxCollider2D myfeet;//auto
    public Animator anim;
    public GameManager gm;//接口: 自动接唯一的GameManager对象的GameManager组件
    public GameObject FloatPoint;
    public GameObject mCamera;
    public bool attacked;
    public bool flag;
    public bool isGround;
    private Vector3 mousepos;
    public Vector3 BossPos;
    public float originA;
    public float accumDamage;
    public int stage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        gm=GameManager.mGM;
        mHero=gm.mHero;
        anim=GetComponent<Animator>();
        myfeet=GetComponent<BoxCollider2D>();
        myRigid=GetComponent<Rigidbody2D>();
        myRigid.velocity=new Vector2(0,0);
        myRigid.gravityScale=gravityScale;
        transform.localScale=new Vector3(-scale,scale,0);
        flag=true;
        attackLastTime=-999f;
        isAttacking=false;
        accumDamage=0;
        //testing
        attacked=false;
        originA=GetComponent<SpriteRenderer>().color.a;
        currHealth=maxHealth;
        stage=0;
        mCamera=gm.mcamera;

        Debug.Assert(FloatPoint!=null);
        Debug.Assert(mCamera!=null);
        Debug.Assert(attackob!=null);
    }
    public void setPos()
    {
        transform.localPosition=BossPos;
    }

    public virtual void takeDamage(float damage)
    {
        currHealth-=damage;
        anim.SetTrigger("takeHit");
        if(currHealth<=0)anim.SetBool("isDead",true);
        StartCoroutine(HitFlashEffect());

        // for float point //
        GameObject e=Instantiate(Resources.Load("Prefabs/DamageAppear") as GameObject);
        e.GetComponent<FloatPointBehavior>().damage=damage;
        e.transform.localPosition=Vector3.zero;
        Vector3 p=transform.localPosition;
        p.x-=(transform.localScale.x/Mathf.Abs(transform.localScale.x))*1f; // according to you flip the character by scale or not
        e.transform.Find("FloatPoint").localPosition=p;


        // for camera shake
        mCamera.GetComponent<CameraShake>().onSignal=true;
    }

    public IEnumerator HitFlashEffect()
    {
        attacked=true;
        yield return new WaitForSeconds(0.1f);
        attacked=false;
    }

    public void ableCo1()
    {
        ba.mycollider.enabled=true;
    }
    public void diableCo1()
    {
        ba.mycollider.enabled=false;
    }

    public virtual void die()
    {
        Destroy(this.gameObject);
    }


    //for anim part
    public void stand()
    {
        myRigid.velocity=Vector3.zero;
        anim.SetBool("Idle",true);
        anim.SetBool("isRun",false);
    }
    public void runLeft()
    {
        myRigid.velocity=new Vector3(-moveSpeed,0,0);
        Vector3 s=transform.localScale;
        s.x=-scale;
        transform.localScale=s;
        anim.SetBool("isRun",true);
    }
    public void runRight()
    {
        myRigid.velocity=new Vector3(moveSpeed,0,0);
        Vector3 s=transform.localScale;
        s.x=scale;
        transform.localScale=s;
        anim.SetBool("isRun",true);
    }

    public void attack()
    {
        anim.SetTrigger("isAttack");
        isAttacking=true;
        attackLastTime=Time.time;
    }
    public Vector3 getPosition()
    {
        Vector3 pos=transform.Find("PositionPoint").position;
        return pos;
    }


}

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public partial class Boss1 : MonoBehaviour
{
    // necessary parameters
    public float maxHealth;
    public float currHealth;
    public float walkSpeed;
    public float minDis;
    public float jumpSpeed;
    public float scale;
    public float attackRange;
    public float moveSpeed;
    public Vector3 rFiringPos;
    public Vector3 lFiringPos;        
    public float flyFireDuringTime;
    public float flyFireCooldown;
    public float pigDuringTime;
    public float lastPigAt;
    public bool isFlyPig;    
    public int timeBeforeAttack;
    public int timeBetweenAttack;
    public int timeDuringAttack;
    public float damage1;
    public float damage2;
    public float damage3;
    public float attackCoolDown;
    public float attackLastTime;

    //may use
    public float gravityScale;    

    // for watching
    public bool isAttacking;
    public bool debugflag;
    public GameObject mHero; //接口：自动接Player GameObject
    public Vector3 firingPos;
    public Rigidbody2D myRigid; //auto
    public BoxCollider2D myfeet;//auto
    public Animator anim;
    public GameManager gm;//接口: 自动接唯一的GameManager对象的GameManager组件
    public GameObject pigCreator;
    public MoveToTarget flyCompo;
    public GameObject mwall;
    public GameObject FloatPoint;
    public GameObject mCamera;
    public GameObject SwordTrap;
    public bool attacked;
    public bool flag;
    public bool isGround;
    private Vector3 mousepos;
    public Vector3 BossPos;
    public float lastFlyFireTime;
    public float lastFlyFireFinishTime;
    public bool isFlyFiring;
    public bool testButton;
    public enum mode{
        stand=0,
        FindAndAttack=1,
        FlyAndFiring=2,
        FlyAndPig=3,
    }
    public mode currmode;
    public BossAttack ba1;
    public float originA;
    public BossAttack ba2;
    public BossAttack ba3;
    public GameObject bulletGene;
    public BulletShootController fire;
    public float lastChangModeTime;
    public float accumDamage;
    public int stage;

    // Start is called before the first frame update
    void Start()
    {
        gm=GameManager.mGM;
        flyCompo=GetComponent<MoveToTarget>();
        mHero=gm.mHero;
        anim=GetComponent<Animator>();
        myfeet=GetComponent<BoxCollider2D>();
        myRigid=GetComponent<Rigidbody2D>();
        myRigid.velocity=new Vector2(0,0);
        myRigid.gravityScale=gravityScale;
        transform.localScale=new Vector3(-scale,scale,0);
        flag=true;
        ba1=util.findGameObject("BossAttack1").GetComponent<BossAttack>();
        ba2=util.findGameObject("BossAttack2").GetComponent<BossAttack>();
        ba3=util.findGameObject("BossAttack3").GetComponent<BossAttack>();
        ba1.damage=damage1;
        ba2.damage=damage2;
        ba3.damage=damage3;
        ba1.off();
        ba2.off();
        ba3.off();
        attackLastTime=-999f;
        isFlyFiring=false;
        isAttacking=false;
        accumDamage=0;
        //testing
        currmode=mode.FindAndAttack;
        flyCompo.speed=moveSpeed;
        testButton=false;
        attacked=false;
        originA=GetComponent<SpriteRenderer>().color.a;
        currHealth=maxHealth;
        bulletGene=util.findGameObject("BossSwordGene");
        bulletGene.GetComponent<BulletShootController>().enabled=false;
        fire=bulletGene.GetComponent<BulletShootController>();
        lastChangModeTime=Time.time;
        currmode=mode.FindAndAttack;
        pigCreator=util.findGameObject("PigGene");
        stage=0;
        mCamera=gm.mcamera;
        SwordTrap=util.findGameObject("SwordGeneTrap");

        Debug.Assert(pigCreator!=null);
        Debug.Assert(FloatPoint!=null);
        Debug.Assert(mCamera!=null);
        Debug.Assert(SwordTrap!=null);
    }
    public void setPos()
    {
        transform.localPosition=BossPos;
    }
    // Update is called once per frame


    void Update()
    {
        if(stage==0||stage==1)
        {
            //always
            isGround = myRigid.IsTouchingLayers(LayerMask.GetMask("Ground"));
            jumpTran();
            mousepos = util.getMousePos();

            if (gm.gameStart == false)
            {
                stand();
            }

            if (gm.gameStart)
            {
                //debuging
                //currmode=mode.FindAndAttack;

                //if(debugflag)Debug.Log($"curr mode: {currmode}");

                // 行为模式
                if (currmode == mode.FindAndAttack)
                {
                    FindAndAttack();
                }
                else if (currmode == mode.stand)
                {
                    stand();
                }
                else if (currmode == mode.FlyAndFiring)
                {
                    flyFiring();
                }
                else if (currmode == mode.FlyAndPig)
                {
                    FlyAndPig();
                }

                // if(Input.GetKeyDown(KeyCode.Space))
                //{
                //perfomeOnce();
                //flag=true;
                //}

                // 攻击闪烁
                if (attacked)
                {
                    Color co = GetComponent<SpriteRenderer>().color;
                    co.a *= originA * 0.5f;
                    GetComponent<SpriteRenderer>().color = co;
                }
                else
                {
                    Color co = GetComponent<SpriteRenderer>().color;
                    co.a = originA;
                    GetComponent<SpriteRenderer>().color = co;
                }
            }
        }

        //testing
        if(Input.GetKeyDown(KeyCode.Mouse3))
        {
            flyTo(mousepos);
            flyCompo.stay=true;
            Debug.Log($"mouse pos: {mousepos}");
        }
        //Debug.Log($"random value: {Random.value}");
        if(Input.GetKeyDown(KeyCode.Y))
        {
            mCamera.GetComponent<CameraShake>().startShakeRoll();
        }
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            changeMode();
        }


        if (mHero.GetComponent<Transform>().transform.localPosition.y>-7)
        {
            SwordTrap.GetComponent<BulletShootController>().enabled=true;
        }
   }

   // private void OnTriggerEnter2D(Collider2D other)
    //{
        //Debug.Log("boss1: onTriggerEnter");
    //}
    void perfomeOnce()
    {
        if(flag)
        {
            flyTo(mousepos);
            flag=false;
        }
    }
    public void takeDamage(float damage)
    {
        currHealth-=damage;
        anim.SetTrigger("takeHit");
        if(currmode==mode.FindAndAttack)accumDamage+=damage;
        if(currHealth<=0)anim.SetBool("isdead",true);
        StartCoroutine(HitFlashEffect());
        // for float point //
        GameObject e=Instantiate(Resources.Load("Prefabs/DamageAppear") as GameObject);
        e.GetComponent<FloatPointBehavior>().damage=damage;
        e.transform.localPosition=Vector3.zero;
        Vector3 p=transform.localPosition;
        p.x-=(transform.localScale.x/Mathf.Abs(transform.localScale.x))*1f; // according to you flip the character by scale or not
        e.transform.Find("FloatPoint").localPosition=p;
        //Instantiate(FloatPoint,transform.localPosition,Quaternion.identity);

        // for camera shake
        mCamera.GetComponent<CameraShake>().onSignal=true;

        if(accumDamage>=100&&currmode==mode.FindAndAttack&&isAttacking==false)
        {
            changeMode();
            accumDamage=0;
        }
        if((currHealth/maxHealth)<0.5f&&stage==0)
        {
            divide();
        }
    }
    private IEnumerator HitFlashEffect()
    {
        attacked=true;
        yield return new WaitForSeconds(0.1f);
        attacked=false;
    }

    void changeMode()
    {
        if(currmode==mode.FindAndAttack)
        {
            //currmode=mode.FlyAndFiring;
            bool flag=Random.value>0.9f;
            Debug.Log($"change mode flag: {flag}");
            //flag=true;
            if(flag)currmode=mode.FlyAndFiring;
            else currmode=mode.FlyAndPig;
            //if(debugflag)Debug.Log($"change mode, now: {currmode}");
            return;
        }
        else if(currmode==mode.FlyAndFiring)
        {
            isFlyFiring = false;
            lastFlyFireFinishTime = Time.time;
            flyCompo.stay = false;
            flyCompo.isMoving = false;
            //myRigid.gravityScale = gravityScale;
            fire.enabled = false;
            myfeet.isTrigger = false;
            currmode=mode.FindAndAttack;
            //Debug.Log("change mode when Fly&Firing");
            return;
        }
        else if(currmode==mode.FlyAndPig)
        {
            finishFlyAndPig();
            currmode=mode.FindAndAttack;
            return;
        }
        else if(currmode==mode.stand)
        {
            currmode=mode.FindAndAttack;
        }
        //testing
    }
    public void ableCo1()
    {
        ba1.mycollider.enabled=true;
    }
    public void diableCo1()
    {
        ba1.mycollider.enabled=false;
    }
    public void ableCo2()
    {
        ba2.mycollider.enabled=true;
    }
    public void diableCo2()
    {
        ba2.mycollider.enabled=false;
    }
    public void ableCo3()
    {
        ba3.mycollider.enabled=true;
    }
    public void diableCo3()
    {
        ba3.mycollider.enabled=false;
        isAttacking=false;
    }
    public void die()
    {
        mwall.GetComponent<ShowBehavior>().Showdown();
        Destroy(this.gameObject);
    }
}

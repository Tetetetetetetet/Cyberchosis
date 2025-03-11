using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public partial class Boss1 : MonoBehaviour
{
    public GameManager gm;//接口: 自动接唯一的GameManager对象的GameManager组件
    public float minDis;
    public bool debugflag;
    public GameObject mHero; //接口：自动接Player GameObject
    public Vector3 firingPos=new Vector3(13.7f,-6f,0f);
    public Rigidbody2D myRigid; //auto
    public BoxCollider2D myfeet;//auto
    public Animator anim;
    public float walkSpeed;
    public float maxHealth;
    public float currHealth;
    public float jumpSpeed;
    public float scale;
    public float attackRange;
    public bool attacked;
    public bool flag;
    public bool isGround;
    private Vector3 mousepos;
    public GameObject hero;
    public MoveToTarget flyCompo;
    public float moveSpeed;
    public int timeBeforeAttack;
    public int timeBetweenAttack;
    public int timeDuringAttack;
    public float damage1;
    public float damage2;
    public float damage3;
    public float attackCoolDown;
    public float attackLastTime;

    // for fly and firing
    public float lastFlyFireTime;
    public float flyFireDuringTime;
    public float lastFlyFireFinishTime;
    public float flyFireCooldown;
    public bool isFlyFiring;
    public bool isAttacking;
    public bool testButton;
    public enum mode{
        stand=0,
        FindAndAttack=1,
        FlyAndFiring=2,
    }
    public mode currmode;
    public BossAttack ba1;
    public float originA;
    public BossAttack ba2;
    public BossAttack ba3;
    public GameObject bulletGene;
    public BulletShootController fire;
    public float lastChangModeTime;

    // Start is called before the first frame update
    void Start()
    {
        gm=GameManager.mGM;
        flyCompo=GetComponent<MoveToTarget>();
        hero=gm.mHero;
        anim=GetComponent<Animator>();
        myfeet=GetComponent<BoxCollider2D>();
        myRigid=GetComponent<Rigidbody2D>();
        mHero=gm.mHero;
        myRigid.velocity=new Vector2(0,0);
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
        //testing
        currmode=mode.FindAndAttack;
        flyCompo.speed=moveSpeed;
        testButton=false;
        attacked=false;
        originA=GetComponent<SpriteRenderer>().color.a;
        currHealth=maxHealth;
        bulletGene=util.findGameObject("randomFire");
        bulletGene.GetComponent<BulletShootController>().enabled=false;
        fire=bulletGene.GetComponent<BulletShootController>();
        lastChangModeTime=Time.time;
    }
    public void setPos()
    {
        transform.localPosition=new Vector3(-21.10972f,-13.99191f,0f);
    }
    // Update is called once per frame


    void Update()
    {
        //always
        isGround=myRigid.IsTouchingLayers(LayerMask.GetMask("Ground"));
        jumpTran();
        mousepos=util.getMousePos();
        if(gm.gameStart==false)
        {
            stand();
        }

        if(gm.gameStart)
        {
            //if(debugflag)Debug.Log($"curr mode: {currmode}");
            //testing
            if(currmode==mode.FindAndAttack)
            {
                FindAndAttack();
            }
            if(currmode==mode.stand)
            {
                stand();
            }
            if(currmode==mode.FlyAndFiring)
            {
                flyFiring();
            }
           // if(Input.GetKeyDown(KeyCode.Space))
            //{
                //perfomeOnce();
                //flag=true;
            //}
            if(Input.GetKeyDown(KeyCode.U))
            {
                changeMode();
            }
            if(attacked)
            {
                Color co=GetComponent<SpriteRenderer>().color;
                co.a*=originA*0.3f;
                GetComponent<SpriteRenderer>().color=co;
            }
            else
            {
                Color co=GetComponent<SpriteRenderer>().color;
                co.a=originA;
                GetComponent<SpriteRenderer>().color=co;
            }
            if((Time.time-lastChangModeTime)>10f)
            {
                changeMode();
                lastChangModeTime=Time.time;
            }
        }
   }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("boss1: onTriggerEnter");
    }
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
        if(currHealth<=0)anim.SetBool("isdead",true);
        StartCoroutine(HitFlashEffect());
    }
    private IEnumerator HitFlashEffect()
    {
        attacked=true;
        yield return new WaitForSeconds(0.1f);
        attacked=false;
    }
    void FindAndAttack()
    {
        Vector3 p=transform.localPosition;
        Vector3 targetpos=hero.transform.localPosition;
        float dis=Mathf.Abs(p.x-targetpos.x);
        if(dis>minDis)
        {
            if(targetpos.x<p.x)
            {
                runLeft();
            }
            else
            {
                runRight();
            }
        }
        else
        {
            stand();
        }

       if(dis<=attackRange)
        {
            if(Mathf.Abs(Time.time-attackLastTime)>attackCoolDown)
            {
                attack1();
            }
            else if(isAttacking==false)
            {
                Debug.Log("under attack range, but cool not down");
            }
        }
        
    }
    void flyFiring()
    {
            if(isFlyFiring==false)
            {
                isFlyFiring=true;
                lastFlyFireTime=Time.time;
                flyCompo.stay=true;
            }
            flyTo(firingPos);
            //...
            if((Time.time-lastFlyFireTime)>flyFireDuringTime&&isAttacking==false)
            {
                isFlyFiring=false;
                lastFlyFireFinishTime=Time.time;
                flyCompo.stay=false;
                flyCompo.isMoving=false;
                changeMode();
            }
            bulletGene.GetComponent<BulletShootController>().enabled=true;
    }
    void changeMode()
    {
        if(currmode==mode.FindAndAttack)
        {
            currmode=mode.FlyAndFiring;
            if(debugflag)Debug.Log($"change mode, now: {currmode}");
            return;
        }
        if(currmode==mode.FlyAndFiring)
        {
            currmode=mode.FindAndAttack;
            flyCompo.isMoving=false;
            fire.enabled=false;
            Debug.Log("change mode when Fly&Firing");
            return;
        }
        //testing
        testButton=!testButton;
    }
    void ableCo1()
    {
        ba1.mycollider.enabled=true;
    }
    void diableCo1()
    {
        ba1.mycollider.enabled=false;
    }
    void ableCo2()
    {
        ba2.mycollider.enabled=true;
    }
    void diableCo2()
    {
        ba2.mycollider.enabled=false;
    }
    void ableCo3()
    {
        ba3.mycollider.enabled=true;
    }
    void diableCo3()
    {
        ba3.mycollider.enabled=false;
        isAttacking=false;
    }
}

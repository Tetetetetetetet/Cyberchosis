using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;

public partial class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
     mHero=gameObject;
    }

     void checkRun()
     {
       float moveIn=Input.GetAxis("Horizontal");
       if(moveIn>0)s.x=scale;
       if(moveIn<0)s.x=-scale;
       if(anim.GetBool("isRoll")==false)
       {
          Vector2 vel=new Vector2(moveIn*speed,myRigid.velocity.y);
          myRigid.velocity=vel;
          bool MoveX=Mathf.Abs(myRigid.velocity.x)>Mathf.Epsilon;
          anim.SetBool("isRun",MoveX);
       }
     }
     void checkJump()
     {
          if(Input.GetKeyDown(KeyCode.W))
          {
               if(isGround)
               {
                    anim.SetBool("Jump",true);
                    Vector2 jump=new Vector2(0f,jumpSpeed);
                    myRigid.velocity=jump;
                    leftJumpTimes=maxJumpTimes-1;
               }
               else if(leftJumpTimes>0)
               {
                    anim.SetBool("Jump",true);
                    Vector2 jump=new Vector2(0f,jumpSpeed);
                    myRigid.velocity=jump;
                    leftJumpTimes--;
               }
          }
          jumpSwitch();
          if(anim.GetBool("Jump")==false&&anim.GetBool("JumpFall")==false&&myRigid.velocity.y<0)
          {
               anim.SetBool("JumpFall",true);
               leftJumpTimes=0;
          }
     }
     void jumpSwitch()
     {
          anim.SetBool("Idle",false);
          if(anim.GetBool("Jump"))
          {
               if(myRigid.velocity.y<=0f)
               {
                    anim.SetBool("Jump",false);
                    anim.SetBool("JumpFall",true);
               }
          }
          else if(isGround)
          {
               anim.SetBool("JumpFall",false);
               anim.SetBool("Idle",true);
          }
     }

     void sword()
     {
          if(Input.GetKeyDown(KeyCode.J))
          {
               anim.SetTrigger("SwordAttack");
               //StartCoroutine(startSwordAttack());
          }

     }

//     IEnumerator startSwordAttack()
     //{
          ////Debug.Log("Start Attack");
          //yield return new WaitForSeconds(timeBeforeAttack);
          ////Debug.Log("HitBox Enable");
          //StartCoroutine(disableHitBox());
     //}
     //IEnumerator disableHitBox()
     //{
          ////Debug.Log("HitBox start disable");
          //yield return new WaitForSeconds(timeAfterAttack);
          ////Debug.Log("Hitbox disabled");
     //}

     void checkCrouch()
     {
          if(Input.GetKeyDown(KeyCode.C))
          {
               anim.SetTrigger("Crouch");
          }
     }

     bool touchingGround()
     {
          bool isGround=myfeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
          if(isGround)leftJumpTimes=maxJumpTimes;
          return isGround;
     }
     void checkComboA()
     {
          if(Input.GetKeyDown(KeyCode.Mouse1))
          {
               anim.SetTrigger("ComboAttackA");
          }
     }
     void checkFire()
     {
          if(Input.GetKeyDown(KeyCode.F))
          {
               anim.SetTrigger("Fire");
               fire();
          }
     }
     void fire()
     {
          GameObject e=Instantiate(Resources.Load("Prefabs/HeroFire")as GameObject);
          e.transform.localPosition=transform.localPosition;
          Vector3 dirc=(Camera.main.ScreenToWorldPoint(Input.mousePosition)-p);
          e.transform.up=dirc.normalized;
          e.GetComponent<HeroBulletBehavior>().mHero=gameObject.GetComponent<PlayerBehavior>();
     }
     /*
     checkDash(): unfinished, bug实在离谱
     */
     void checkDash()
     {
          bool isDash=anim.GetBool("isDash");
          Debug.Log($"checkDash at {Time.time}, isDash: {isDash}");
          if(Input.GetKeyDown(KeyCode.LeftAlt))
          {
               Debug.Log("got alt");
               anim.SetBool("isDash",true);
               isDash=true;
               dashPos=p;
               dashStartPos=p;
               lastDashAt=Time.time;
               if(s.x>0)
               {
                    dashPos.x+=dashDis;
               }
               else if(s.x<0)
               {
                    dashPos.x-=dashDis;
               }
          }
          if(isDash)
          {
               info=anim.GetCurrentAnimatorStateInfo(0);
               float percent=info.normalizedTime;
               float x=percent*(dashPos.x-p.x)+p.x;
               p.x=x;
               Debug.Log($"percent: {percent}, p.x:{p.x}");
          }
          if(Mathf.Abs(dashPos.x-p.x)/Mathf.Abs(dashStartPos.x-p.x)<0.1)
          {
               Debug.Log($"dash finish, {dashStartPos.x}->{dashPos.x}, now {p.x}");
               anim.SetBool("isDash",false);
          }
     }
     void checkBow()
     {

     }
     void checkThrow()
     {
          if(Input.GetKeyDown(KeyCode.E))
          {
               Debug.Log("get E");
               anim.SetTrigger("Throw");
          }
     }

     void checkGroundSlam()
     {
          if(Input.GetKeyDown(KeyCode.V))
          {
               anim.SetTrigger("GroundSlam");
          }
     }
     void die()
     {
          anim.SetTrigger("Die");
          gm.loseGame();
     }
     void checkRoll()
     {
          float timedis=Mathf.Abs(Time.time-lastRollAt);
          if(Input.GetKeyDown(KeyCode.LeftAlt))
          {
               Debug.Log("start roll");
               anim.SetBool("isRoll",true);
               anim.SetBool("isRun",false);
               myRigid.isKinematic=true;
               myfeet.isTrigger=true;
               lastRollAt=Time.time;
               timedis=Mathf.Abs(Time.time-lastRollAt);
               if(Mathf.Abs(Time.time-lastRollAt)>rollCooldown&&(anim.GetBool("isRun")||anim.GetBool("Idle")))
               {
               }
          }
          if(anim.GetBool("isRoll"))
          {
               myRigid.velocity=new Vector2(rollSpeed*s.x/Mathf.Abs(s.x),0);
          }

          if(anim.GetBool("isRoll")&&timedis>rollDuringTime)
          {
               anim.SetBool("isRoll",false);
               anim.SetBool("Idle",true);
               myRigid.isKinematic=false;
               myfeet.isTrigger=false;
          }
     }
     public void onFrameSword()
     {
          //Debug.Log("hero sword attack");
          HeroSwordBehavior hsb=mySword.GetComponent<HeroSwordBehavior>();
          hsb.sword.enabled=true;
     }
     public void onFrameSworded()
     {
          HeroSwordBehavior hsb=mySword.GetComponent<HeroSwordBehavior>();
          hsb.sword.enabled=false;
     } 
     void action()
     {
          checkRun();
          checkJump();
          checkComboA();
          sword();
          checkCrouch();
          checkBow();
          checkFire();
          checkGroundSlam();
          checkThrow();
          checkRoll();
     }


}

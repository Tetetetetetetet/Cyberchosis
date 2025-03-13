using UnityEngine;

public partial class Boss1 : MonoBehaviour
{
    void runLeft()
    {
        transform.localScale=new Vector3(-scale,scale,0);
        myRigid.velocity=new Vector2(-walkSpeed,0);
        anim.SetBool("isRun",true);
    }
    void runRight()
    {
        transform.localScale=new Vector3(scale,scale,0);
        myRigid.velocity=new Vector2(walkSpeed,0);
    }
    void stand()
    {
        anim.SetBool("isRun",false);
        Vector2 v=myRigid.velocity;
        v.x=0;
        myRigid.velocity=v;
    }
    void attack1()
    {
        Debug.Log("boss attack");
        anim.SetTrigger("isattack");

        attackLastTime=Time.time;
        isAttacking=true;
        //ba1.anim.SetTrigger("isattack");
        //ba2.anim.SetTrigger("isattack");
        //ba3.anim.SetTrigger("isattack");
        //StartCoroutine(StartAttack1());
    }


    void jump()
    {
        Debug.Log("boss jump");
        anim.SetBool("isJump",true);
        Vector2 v=myRigid.velocity;
        v.y=jumpSpeed;
        myRigid.velocity=v;
    }
    void jumpTran()
    {
        if(myRigid.velocity.y<=0)
        {
            anim.SetBool("isJump",false);
            anim.SetBool("isJumpFall",true);
        }
        if(isGround)
        {
            anim.SetBool("isJumpFall",false);
            anim.SetBool("isIdle",true);
        }
        else
        {
            anim.SetBool("isJumpFall",true);
        }
    }
    void flyTo(Vector3 pos)
    {
        Debug.Log("boss: flyto");
        Debug.Assert(flyCompo!=null);
        flyCompo.StartMoving(pos);
    }
    void switchStatus()
    {

    }
}
 //   private IEnumerator StartAttack1()
    //{
        //for(int i=0;i<timeBeforeAttack;i++)
        //{
            //Debug.Log($"waiting: {i}/{timeBeforeAttack}");
            //yield return new WaitForFixedUpdate();
        //}
        //ba1.on();
        //StartCoroutine(disableAttack1());
    //}
    //private IEnumerator disableAttack1()
    //{
        //for(int i=0;i<timeDuringAttack;i++)yield return new WaitForFixedUpdate();
        //ba1.off();
        //StartCoroutine(StartAttack2());
    //}
    //private IEnumerator StartAttack2()
    //{
        //for(int i=0;i<timeBetweenAttack;i++)yield return new WaitForFixedUpdate();
        //ba2.on();
        //StartCoroutine(disableAttack2());
    //}
    //private IEnumerator disableAttack2()
    //{
        //for(int i=0;i<timeDuringAttack;i++) yield return new WaitForFixedUpdate();
        //ba2.off();
        //StartCoroutine(StartAttack3());
    //}
   //IEnumerator StartAttack3()
    //{
        //for(int i=0;i<timeBetweenAttack;i++)yield return new WaitForFixedUpdate();
        //ba3.on();
        //StartCoroutine(disableHitbox());
    //}
    //IEnumerator disableHitbox()
    //{
        //for(int i=0;i<timeDuringAttack;i++)yield return new WaitForFixedUpdate();
        //ba3.off();
        //isAttacking=false;
    //}
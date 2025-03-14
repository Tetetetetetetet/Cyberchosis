using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Boss1 : MonoBehaviour
{
    // Start is called before the first frame update
    void FindAndAttack()
    {
        Vector3 p = transform.localPosition;
        Vector3 targetpos = mHero.transform.localPosition;
        float dis = Mathf.Abs(p.x - targetpos.x);
        if (dis > minDis)
        {
            if (targetpos.x < p.x)
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

        if (dis <= attackRange)
        {
            if (Mathf.Abs(Time.time - attackLastTime) > attackCoolDown)
            {
                attack1();
            }
            else if (isAttacking == false)
            {
                Debug.Log("under attack range, but cool not down");
            }
        }

    }

    void flyFiring()
    {
        //myRigid.gravityScale=0;
        myfeet.isTrigger = true;
        if (isFlyFiring == false)
        {
            isFlyFiring = true;
            lastFlyFireTime = Time.time;
            flyCompo.stay = true;
            if (gm.mHero.transform.localPosition.x >= transform.localPosition.x)
            {
                firingPos = rFiringPos;
                transform.localScale = new Vector3(-scale, scale, 0);
            }
            else
            {
                firingPos = lFiringPos;
                transform.localScale = new Vector3(scale, scale, 0);
            }
            flyTo(firingPos);

        }
        //...
        if ((Time.time - lastFlyFireTime) > flyFireDuringTime && isAttacking == false)
        {
            isFlyFiring = false;
            lastFlyFireFinishTime = Time.time;
            flyCompo.stay = false;
            flyCompo.isMoving = false;
            //myRigid.gravityScale = gravityScale;
            fire.enabled = false;
            myfeet.isTrigger = false;
            changeMode();
        }
        bulletGene.GetComponent<BulletShootController>().enabled = true;
    }


    void FlyAndPig()
    {
        myfeet.isTrigger = true;
        if (isFlyPig == false)
        {
            isFlyPig = true;
            flyCompo.stay = true;
            if (gm.mHero.transform.localPosition.x >= transform.localPosition.x)
            {
                firingPos = rFiringPos;
                transform.localScale = new Vector3(-scale, scale, 0);
            }
            else
            {
                firingPos = lFiringPos;
                transform.localScale = new Vector3(scale, scale, 0);
            }
            flyTo(firingPos);
            pigCreator.isActive = true;
            lastPigAt = Time.time;

        }
        if ((Time.time - lastPigAt) > pigDuringTime)
        {
            finishFlyAndPig();
        }
    }
    void finishFlyAndPig()
    {
        pigCreator.isActive = false;
        myfeet.isTrigger=false;
        flyCompo.stay = false;
        flyCompo.isMoving = false;
        changeMode();
    }
}

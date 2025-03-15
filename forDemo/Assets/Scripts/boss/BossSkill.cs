using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        if(bulletGene.GetComponent<BulletShootController>().enabled==true)
        {
            bulletGene.GetComponent<BulletShootController>().enabled=false;
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
            pigCreator.GetComponent<CreatePig>().isActive = true;
            lastPigAt = Time.time;
        }
        if ((Time.time - lastPigAt) > pigDuringTime)
        {
            changeMode();
        }
    }
    void finishFlyAndPig()
    {
        pigCreator.GetComponent<CreatePig>().isActive = false;
        myfeet.isTrigger=false;
        flyCompo.stay = false;
        flyCompo.isMoving = false;
        changeMode();
    }

    void divide()
    {
        stage=1;
        if(currmode!=mode.FindAndAttack)
        {
            changeMode();
        }
        CameraShake cs=mCamera.GetComponent<CameraShake>();
        cs.duration=2;
        cs.intensity=10;
        cs.startShake();
        Debug.Assert(mwall!=null);
        mwall.GetComponent<ShowBehavior>().onSignal=true;
        if(mHero.transform.localPosition.x<-11.2f)
        {
            mHero.GetComponent<PlayerBehavior>().maxX=-11.2f;
            Vector3 p=transform.localPosition;
            p.x=-36f;
            transform.localPosition=p;
            rFiringPos=lFiringPos;
        }
        else
        {
            Vector3 p=transform.localPosition;
            p.x=16f;
            transform.localPosition=p;
            mHero.GetComponent<PlayerBehavior>().minX=-8.4f;
            lFiringPos=rFiringPos;
        }
    }

    void phantom()
    {

    }
}

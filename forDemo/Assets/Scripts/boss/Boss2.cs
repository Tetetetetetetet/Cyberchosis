using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss2 : BossBehavior
{  
    public enum mode{
        stand=0,
        FindAndAttack=1,
        StandAndSkill=2,
    }
    public mode currmode;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        currmode=mode.FindAndAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if(currmode==mode.FindAndAttack)
        {
            FindAndAttack();
        }
    }

    public override void runRight()
    {
        
    }

    void FindAndAttack()
    {
        Vector3 pos = getPosition();
        Vector3 heropos = gm.mHero.transform.localPosition;
        float dis = Mathf.Abs(pos.x - heropos.x);
        if (dis > minDis)
        {
            if (pos.x > heropos.x)
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
        if (dis < attackRange && (Time.time - attackLastTime) > attackCoolDown)
        {
            attack();
        }
        else if ((Time.time - attackLastTime) > attackCoolDown)
        {
            Debug.Log("boss want to attack, but cool not down");
        }
    }
    public override void takeDamage(float damage)
    {
        currHealth -= damage;
        anim.SetTrigger("takeHit");
        if (currHealth <= 0) anim.SetBool("isDead", true);
        StartCoroutine(HitFlashEffect());

        // for float point //
        GameObject e = Instantiate(Resources.Load("Prefabs/DamageAppear") as GameObject);
        e.GetComponent<FloatPointBehavior>().damage = damage;
        e.transform.localPosition = Vector3.zero;
        Vector3 p = getPosition();
        p.x -= (transform.localScale.x / Mathf.Abs(transform.localScale.x)) * 1f; // according to you flip the character by scale or not
        e.transform.Find("FloatPoint").localPosition = p;


        // for camera shake
        mCamera.GetComponent<CameraShake>().onSignal = true;
    }
}

using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CameraForScene2 : CameraSupport
{
    // Start is    public Vector3 initPos;
    public float moveSpeed;
    public float finalPosX;
    public Vector3 initPos;

    private bool animFlag;
    void Start()
    {
        gm=GameManager.mGM;
        animFlag=false;
    }

    // Update is called once per frame


    public override void enterAnim()
    {
        if(animFlag==false)
        {
            p=initPos;
            animFlag=true;
        }
        else
        {
            p.x+=moveSpeed*Time.smoothDeltaTime;
        }
        if(p.x>finalPosX)
        {
            startGame();
        }
   }


    void Update()
    {
        p=transform.localPosition;
        //game start
        if(gm.gameStart)
        {
            followHero();
            p.z=-15f;
        }
        else if(gm.isEnterAnim)
        {
            enterAnim();
        }
        p.z=-15f;
        transform.localPosition=p;
        //always

    }
}


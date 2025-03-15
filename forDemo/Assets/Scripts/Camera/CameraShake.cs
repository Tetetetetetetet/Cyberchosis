using UnityEngine;
using System;

public class CameraShake : MonoBehaviour
{
    public float duration, intensity,tim;
    public float srDuration,srIntensity,srTim;
    public float oDuration,oIntensity;
    public float A;
    bool stat=false;
    GameObject e =null;
    Vector3 p=new Vector3(0,0,0);
    public bool onSignal,isActive,srOnSignal,srIsActive;

    //GameObject cameraobject=null;
    void Start()
    {
        onSignal=false;
        isActive=false;
        oDuration=duration;
        oIntensity=intensity;
        srOnSignal=false;
    }
    public void startShake()
    {
        onSignal=true;
        //Invoke("resetConfig",2);
    }
    public void startShakeRoll()
    {
        srOnSignal=true;
    }
    public void resetConfig()
    {
        duration=oDuration;
        intensity=oIntensity;
    }
    // Update is called once per frame
    void Update()
    {
        if(tim>0) 
        {
            //Debug.Log("SSHHAAKKEECCMMEERRAA");
            shake();
        }
        else if(srTim>0)
        {
            shakeRoll();
        }
        else if(stat==true)
        {
            transform.localPosition=p;
            stat=false;
        }
        //if(Input.GetKeyDown(KeyCode.R))
        if(onSignal==true&&isActive==false)
        {
            isActive=true;
            stat=true;
            p=transform.localPosition;
            tim=duration;
            //Debug.Log("SSHHAAKKEECCMMEERRAA");
        }
        else if(onSignal==true&&isActive==true&&tim<=0)
        {
            onSignal=false;
            isActive=false;
        }
        if(srOnSignal==true&&srIsActive==false)
        {
            srIsActive=true;
            stat=true;
            p=transform.localPosition;
            srTim=srDuration;
            //Debug.Log("SSHHAAKKEECCMMEERRAA");
        }
        else if(srOnSignal==true&&srIsActive==true&&srTim<=0)
        {
            srOnSignal=false;
            srIsActive=false;
        }

    }
    void shake()
    {
        tim-=Time.deltaTime;
        Debug.Log("SSHHAAKKEECCMMEERRAA");
        Vector3 q=transform.localPosition;
        float x=q.x+UnityEngine.Random.Range(-1,1)*intensity*Time.deltaTime;
        q.x=x;
        transform.localPosition=q;
    }

    void shakeRoll()
    {
        srTim-=Time.deltaTime;
        if(srTim>=0)
        {
            Vector3 p=transform.localPosition;
            float shakeAmount=A*MathF.Sin(srIntensity*MathF.PI*2/srDuration*Time.time)*UnityEngine.Random.Range(0f,1f);
            p.y+=shakeAmount;
            transform.localPosition=p;
        }
    }
    // void Update()//这段放到CameraSupport的void Update里面，当相机抖动时不follow hero
    // {
    //     //game start
    //     if(gm.gameStart)
    //     {
    //         p=transform.localPosition;
    //         GameObject e=this.gameObject;
    //         CameraShake scrpt=e.GetComponent<CameraShake>();
    //         if(scrpt!=null)
    //         {
    //             float tim=scrpt.tim;
                
    //             Debug.Log(tim);
    //             if(tim<=0) 
    //                 followHero();
    //         }
            
    //     }

    //     //always

    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration, intensity,tim;
    public float oDuration,oIntensity;
    bool stat=false;
    GameObject e =null;
    Vector3 p=new Vector3(0,0,0);
    public bool onSignal,isActive;

    //GameObject cameraobject=null;
    void Start()
    {
        onSignal=false;
        isActive=false;
        oDuration=duration;
        oIntensity=intensity;
    }
    public void startShake()
    {
        onSignal=true;
        Invoke("resetConfig",2);
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
            Debug.Log("SSHHAAKKEECCMMEERRAA");

        }
        else if(onSignal==true&&isActive==true&&tim<=0)
        {
            onSignal=false;
            isActive=false;
        }
    }
    void shake()
    {
        tim-=Time.deltaTime;
        Debug.Log("SSHHAAKKEECCMMEERRAA");
        Vector3 q=transform.localPosition;
        float x=q.x+Random.Range(-1,1)*intensity*Time.deltaTime;
        q.x=x;
        transform.localPosition=q;
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

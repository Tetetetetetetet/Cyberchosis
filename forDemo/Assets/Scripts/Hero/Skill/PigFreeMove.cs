using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigFreeMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float HSpeed;
    bool dirc=true;
    public float damage;
    public Rigidbody2D myRigid;
    void Start()
    {
        HSpeed=5.0f;
        myRigid=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p=transform.localPosition;
        if(p.y!=-20.9f) p.y=-20.9f;
        transform.localPosition=p;
        //Debug("dirc");
        if(dirc==true)
        {
            myRigid.velocity=new Vector2(HSpeed,0);
        }
        else{
            myRigid.velocity=new Vector2(-HSpeed,0);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        // 检查触发器碰撞的物体
        if (other.gameObject.CompareTag("Player"))
        {
            //
            //other.gameObject.GetComponent<PlayerBehavior>.takeDamage(damage);
            //
            PlayerBehavior playerBehavior = other.gameObject.GetComponent<PlayerBehavior>();
            if (playerBehavior != null)
            {
                playerBehavior.takeDamage(damage);
            }   
            // if(dirc==true)
            // {
            //     Vector3 p=transform.localPosition;
            //     p.x-=2.0f;
            //     transform.localPosition=p;
            // }
            // else{
            //     Vector3 p=transform.localPosition;
            //     p.x+=2.0f;
            //     transform.localPosition=p;
            // }
        }
        else
        {
            if(other.gameObject.CompareTag("Wall"))
            {
                if(dirc==true) 
            {
                dirc=false;
                // Vector3 p=transform.localPosition;
                // p.x+=1.0f;
                // transform.localPosition=p;
            }
            else 
            {
                dirc=true;
                // Vector3 p=transform.localPosition;
                // p.x-=1.0f;
                // transform.localPosition=p;
            }
            }
            
        }
    }
    // public void OnCollisionStay2D(Collision2D other)
    // {
    //     Debug.Log("cs");
    // }
    // public void OnTriggerrEnter2D(Collider2D other)
    // {
    //     Debug.Log("te");
    // }
    // public void OnTriggerStay2D(Collider2D other)
    // {
    //     Debug.Log("ts");
    // }
  
}

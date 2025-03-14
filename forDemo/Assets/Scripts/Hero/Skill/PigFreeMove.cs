using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigFreeMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float HSpeed;
    public bool dirc=false;
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
        //Debug.Log("ce");
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
            MakeDestroy();
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
            
            if(other.gameObject.CompareTag("ground")){}
            //else if(other.gameObject.CompareTag("Boss")){Debug.Log("COllisionwithBoss");}
            else
            {
                if(dirc==true) 
                {
                dirc=false;
                // Vector3 p=transform.localPosition;
                // p.x+=1.0f;
                // transform.localPosition=p;
                }
                else dirc=true;
            }
            if(other.gameObject.CompareTag("Pig"))
            {
                GameObject temp=other.gameObject;
                Vector3 p=temp.transform.localPosition;
                Vector3 q=transform.localPosition;
                if(p.x<q.x) q.x+=0.1f;
                else q.x-=0.1f;
                transform.localPosition=q;
            }
           
            
        }
    }
    public void OnCollisionStay2D(Collision2D other)
    {
         GameObject temp=other.gameObject;
                Vector3 p=temp.transform.localPosition;
                Vector3 q=transform.localPosition;
                if(p.x<q.x) q.x+=0.1f;
                else q.x-=0.1f;
                transform.localPosition=q;
    }
    public void MakeDestroy()
    {
        Destroy(this.gameObject);
    }
  
}

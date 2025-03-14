using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakePigBoss : MonoBehaviour 

{
    public static void Pig(float f,int num)
    {
        
        float FloorY=-20.9f;
        Vector3 p;
        p= new Vector3(0,0,0);
        //GameObject e=GameObject.Find("Boss");
        //p=e.transform.localPosition;
        p.x=f;
        if(p.x<-15.0f)
            p.x=-15.0f;
        p.y=FloorY;
        for(int i=1;i<=5;i++)
        {
            GameObject x = Instantiate(Resources.Load("Prefabs/AngryPig") as GameObject);
            p.x-=4.5f;
            x.transform.localPosition=p;

        }
    }
}

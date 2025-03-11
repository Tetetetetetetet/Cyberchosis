using UnityEngine;

public class LiftClass
{
    // Start is called before the first frame update
    public static void LiftByBool(GameObject e,bool lift,float VSpeed,float UpBound,float LowBound)
    {
        Vector3 p=e.transform.localPosition;
        if(lift==true&&p.y<=UpBound)
        {            
            p.y+=VSpeed*Time.deltaTime;
        }
        if(lift==false&&p.y>=LowBound)
        {
            p.y-=VSpeed*Time.deltaTime;
        }
        
        e.transform.localPosition=p;
    }
}

using UnityEngine;

public class LiftPlatform : MonoBehaviour
{
    public bool lift;
    public float VSpeed=2.0f,UpBound=-11.0f,LowBound=-22.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p=transform.localPosition;
        
        if(p.y>UpBound)
        {
            lift=false;
           // Destroy(transform.gameObject);
        }
        if(p.y<LowBound)
        {
            lift=true;
        }
        GameObject e=this.gameObject;
        LiftClass.LiftByBool(e,lift,VSpeed,UpBound,LowBound);
    }
    
}

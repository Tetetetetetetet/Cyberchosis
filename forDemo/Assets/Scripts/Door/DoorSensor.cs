using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorManager dm=null;    
    void Start()
    {
        dm=DoorManager.tDoorManager;
        Debug.Assert(dm!=null);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p=transform.localPosition;
        int isIn=0;
        if(dm.active)
        {
            if(p.x<(dm.center1+dm.radius)&&p.x>(dm.center1-dm.radius))isIn=1;
            else if(p.x<(dm.center2+dm.radius)&&p.x>(dm.center2-dm.radius))isIn=2;
            else isIn=0;
        }
        if(isIn==1&&(Time.time-dm.lastTime)>dm.coolDownTime)
        {
            p.x=dm.center2;
            dm.lastTime=Time.time;
        }
        else if(isIn==2&&(Time.time-dm.lastTime)>dm.coolDownTime)
        {
            p.x=dm.center1;
            dm.lastTime=Time.time;
        }
        transform.localPosition=p;
    }
}

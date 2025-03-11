using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DoorManager tDoorManager;
    public float radius;
    public bool active=false;
    public float center1;
    public float coolDownTime;
    public float lastTime;
    public float center2;
    public void called(float c1,float c2)
    {
        active=true;
        c1=center1;
        c2=center2;
    }
    public void shut()
    {
        active=false;
    }
    void Start()
    {
        tDoorManager=this;
        Debug.Assert(tDoorManager!=null);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

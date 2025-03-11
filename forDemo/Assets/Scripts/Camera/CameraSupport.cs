using UnityEngine;

public class CameraSupport : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPos=new Vector3(0,0,-15);
    public Vector3 p;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float smoothRate;
    private GameManager gm;
    public static Camera mCamera;
    private int followTo;//0:hero, 1:boss
    void Start()
    {
        followTo=0;
        gm=GameManager.mGM;
        Vector3 p=gm.mHero.transform.localPosition;
        p.z=zOffset;
        transform.localPosition=p;
    }

    // Update is called once per frame
    void followHero()
    {
        if(gm.mHero!= null)targetPos=gm.mHero.transform.localPosition;
        targetPos.x+=xOffset;
        targetPos.y+=yOffset;
        p=Vector3.Lerp(targetPos,transform.localPosition,smoothRate);
        p.z=zOffset;
        if(p.x>=maxX)p.x=maxX;
        if(p.x<=minX)p.x=minX;
        if(p.y>=minY)p.y=minY;
        if(p.y<=maxY)p.y=maxY;
    }
    void enterAnim()
    {
        Camera.main.orthographicSize=4;
        if(followTo==0)
        {
            p=new Vector3(-40,-18,-15);
            Invoke("focusBoss",1);
        }
        else if(followTo==1)
        {
           // gm.Boss.GetComponent<BossControl>().Patrol();
            focusBoss();
        }
    }
    void focusBoss()
    {
        followTo=1;
        //Debug.Log($"p:{p},Boss:{gm.Boss.GetComponent<Transform>().transform.localPosition}");
        //p=gm.Boss.GetComponent<Transform>().transform.localPosition;
        p=new Vector3(17,-18,-15);
        Invoke("startGame",1);
    }
    void startGame()
    {
        followTo=-1;
        gm.gameStart=true;
        Camera.main.orthographicSize=10;
    }
    void Update()
    {
        p=transform.localPosition;
        if(gm.gameStart)followHero();
        else enterAnim();
        p.z=-15f;
        transform.localPosition=p;
    }
}


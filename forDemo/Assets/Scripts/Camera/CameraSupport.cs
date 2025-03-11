using UnityEngine;

public class CameraSupport : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPos=new Vector3(0,0,-15);
    public float cameraSize;
    public Vector3 p;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float smoothRate;
    public GameManager gm;
    public static Camera mCamera;
    private int followTo=0;//0:hero, 1:boss
    void Start()
    {
        gm=GameManager.mGM;
        if(followTo==0)enterAnim();
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
        if(p.y<=minY)p.y=minY;
        if(p.y>=maxY)p.y=maxY;
    }
    public void enterAnim()
    {
        Debug.Log("enter animation");
        Camera.main.orthographicSize=5;
        //if(followTo==0)
        //{
            //Invoke("focusBoss",1);
        //}
           // gm.Boss.GetComponent<BossControl>().Patrol();
        focusBoss();
    }
    public void focusBoss()
    {
        followTo=1;
        //Debug.Log($"p:{p},Boss:{gm.Boss.GetComponent<Transform>().transform.localPosition}");
        //p=gm.Boss.GetComponent<Transform>().transform.localPosition;
        p=new Vector3(-10f,-17f,-15f);
        Invoke("startGame",1);
    }
    public void startGame()
    {
        Debug.Log("camera: startGame");
        followTo=-1;
        gm.gameStart=true;
        Camera.main.orthographicSize=cameraSize;
    }
    void Update()
    {
        //game start
        if(gm.gameStart)
        {
            p=transform.localPosition;
            followHero();
            p.z=-15f;
        }

        transform.localPosition=p;
        //always

    }
}


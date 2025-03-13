using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CameraForScene2 : MonoBehaviour
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
    public GameManagerForScene2 gm;
    public static Camera mCamera;
    public Vector3 BossPos;//有Boss则设置，做开场聚焦
    private bool animFlag;
    void Start()
    {
        gm=GameManagerForScene2.mGM;
        animFlag=false;
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
    public Vector3 initPos;
    public float moveSpeed;
    public float finalPosX;
    public void enterAnim()
    {
        if(animFlag==false)
        {
            p=initPos;
            animFlag=true;
        }
        else
        {
            p.x+=moveSpeed*Time.smoothDeltaTime;
        }
        if(p.x>finalPosX)
        {
            startGame();
        }
   }

    public void startGame()
    {
        Debug.Log("camera: startGame");
        gm.gameStart=true;
        Camera.main.orthographicSize=cameraSize;
    }

    void Update()
    {
        p=transform.localPosition;
        //game start
        if(gm.gameStart)
        {
            followHero();
            p.z=-15f;
        }
        else if(gm.isEnterAnim)
        {
            enterAnim();
        }
        p.z=-15f;
        transform.localPosition=p;
        //always

    }
}


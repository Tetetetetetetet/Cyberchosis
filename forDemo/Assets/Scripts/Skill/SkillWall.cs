using UnityEngine;

public class SkillWall : MonoBehaviour
{
    public Camera mainCamera=null;
    GameObject mHero;
    GameObject e=null;
    public static float Existingtime=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool dir;
    // Update is called once per frame
    void Update()
    {
        //Existingtime-=Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse4))
        {
            Vector3 p=transform.localPosition;
            e = Instantiate(Resources.Load("Prefabs/Platpre") as GameObject);
            BuilPlat.Create(e,p);
            //Create();
            //Existingtime=10.0f;
            //MyDestroy(e,Existingtime);
        }
        if(e!=null)
        {
            UpdWall();
        }
    }
    public void UpdWall()
    {
        Debug.Log("hey");
        LiftClass.LiftByBool(e,true,3.0f,-16.0f,-30);
    }

    // public void Create()
    // {
    //     Debug.Log("Createupd");
    //     Vector3 p = transform.localPosition;
    //     e = Instantiate(Resources.Load("Prefabs/Platpre") as GameObject);      
        
    //     p.x+=4.0f;
    //     p.y=-22.0f;
    //     Vector3 sz=transform.localScale;
        
    //     e.transform.localScale=sz;
    //     e.transform.localPosition = p;
    //     //e.AddComponent(System.Type.GetType("LiftPlatform"));
    //     e.name = "CreateWall";
    //     string objectXName=e.name;
    //     GameObject objectX = GameObject.Find(objectXName);        
    //     Transform childf;
    //     childf=e.transform.Find("Wall3");
    //     GameObject childObject = null; // 声明变量，确保其作用域覆盖整个方法
    //     childObject = childf.gameObject;        
        
    //     if (childObject != null)
    //     {
    
    //         SpriteRenderer spriteRenderer = childObject.GetComponent<SpriteRenderer>();
    //         if (spriteRenderer != null)
    //         {
    //             spriteRenderer.sortingOrder = 2;
    //         }
    //         else
    //         {
    //             Debug.LogError("SpriteRenderer component not found on child object!");
    //         }
    //     }
    //     childf=e.transform.Find("WallD");
    //     childObject = null; // 声明变量，确保其作用域覆盖整个方法
    //     childObject = childf.gameObject;        
    //     if (childObject != null)
    //     {
    
    //         SpriteRenderer spriteRenderer = childObject.GetComponent<SpriteRenderer>();
    //         if (spriteRenderer != null)
    //         {
    //             spriteRenderer.sortingOrder = 2;
    //         }
    //         else
    //         {
    //             Debug.LogError("SpriteRenderer component not found on child object!");
    //         }
    //     }
    // }
}

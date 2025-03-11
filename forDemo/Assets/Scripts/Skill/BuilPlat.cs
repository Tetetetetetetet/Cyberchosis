using UnityEngine;

public class BuilPlat 
{
    // Start is called before the first frame update
    public static void Create(GameObject e,Vector3 p)
    {
        Debug.Log("Createupd");          
       
        
        p.x+=4.0f;
        p.x=Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        p.y=-24.0f;
        //Vector3 sz=transform.localScale;
        
        //e.transform.localScale=sz;
        e.transform.localPosition = p;
        //e.AddComponent(System.Type.GetType("LiftPlatform"));
        e.name = "CreateWall";
        string objectXName=e.name;
        GameObject objectX = GameObject.Find(objectXName);

        
        Transform childf;
        childf=e.transform.Find("Wall3");
        GameObject childObject = null; // 声明变量，确保其作用域覆盖整个方法
        childObject = childf.gameObject;        
        
        if (childObject != null)
        {
    
            SpriteRenderer spriteRenderer = childObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = 2;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on child object!");
            }
        }
        childf=e.transform.Find("WallD");
        childObject = null; // 声明变量，确保其作用域覆盖整个方法
        childObject = childf.gameObject;        
        if (childObject != null)
        {
    
            SpriteRenderer spriteRenderer = childObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = 2;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on child object!");
            }
        }
    }
}

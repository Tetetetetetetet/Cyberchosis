using UnityEngine;

public class util : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 getMousePos()
    {
        Vector3 mouse=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mouse;
    }
    public static GameObject findGameObject(string name)
    {
        return GameObject.Find(name);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

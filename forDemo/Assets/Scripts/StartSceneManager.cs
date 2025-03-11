using UnityEngine;
using UnityEngine.SceneManagement; // 添加此行

public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 mousePos;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (mousePos.x < 23 && mousePos.x > -25 && mousePos.y < 16 && mousePos.y > 4)
            {
                SceneManager.LoadScene("Scene1"); // 修正拼写错误
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
public class BacktoStart : MonoBehaviour
{   
    public string sceneName; // 要切换到的场景名称

    // 当按钮被点击时调用的方法
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}

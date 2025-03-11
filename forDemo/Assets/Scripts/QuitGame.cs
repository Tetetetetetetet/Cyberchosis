using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    public Button quitButton; // 要绑定的退出按钮

    void Start()
    {
        // 确保按钮不为空
        if (quitButton != null)
        {
            // 为按钮的点击事件添加监听器
            quitButton.onClick.AddListener(GameQuit);
        }
        else
        {
            Debug.LogError("退出按钮未设置！");
        }
    }

    // 退出游戏的方法
    void GameQuit()
    {
        // 在编辑器中运行时，直接退出应用
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

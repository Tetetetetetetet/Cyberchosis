using UnityEngine;
using UnityEngine.UI;

public class StartGameDialog : MonoBehaviour
{
    public GameObject dialogPanel;  // UI 面板

    void Start()
    {
        dialogPanel.SetActive(true);  // 显示弹窗
        Time.timeScale = 0;  // 暂停游戏
        AudioListener.pause = true;  // 暂停所有音频

    }

    public void OnOKButtonClicked()
    {
        dialogPanel.SetActive(false); // 关闭弹窗
        Time.timeScale = 1;  // 恢复游戏
        AudioListener.pause = false;  // 暂停所有音频
    }
}

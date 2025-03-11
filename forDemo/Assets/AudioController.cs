using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;  // 负责播放音频的组件
    public AudioClip startClip;  // 开始时播放的音频
    public AudioClip bgmClip;  // 背景音乐
    public AudioClip endClip;  // 结束时播放的音频

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        // 播放开始音频
        audioSource.clip = startClip;
        audioSource.volume=1f;
        audioSource.Play();
        yield return new WaitForSeconds(startClip.length);  // 等待音频播放完

        // 播放 BGM
        audioSource.clip = bgmClip;
        audioSource.loop = true;  // 设置循环播放
        audioSource.volume=0.05f;
        audioSource.Play();
        
        // 等待游戏结束 (这里你可以加一个触发条件)
        yield return new WaitUntil(() => GameManager.isGameOver);  // 这里假设 GameManager 里有 isGameOver 标志

        // 播放结束音频
        audioSource.loop = false;  // 关闭循环播放
        audioSource.clip = endClip;
        audioSource.volume=1f;
        audioSource.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScene");
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource1;  // 负责播放音频的组件
    public AudioSource audioSource2; // Boss念技能
    public AudioSource audioSource3; // 角色音效
    public AudioClip startClip;  // 开始时播放的音频
    public AudioClip bgmClip;  // 背景音乐
    public AudioClip endClip;  // 结束时播放的音频
    public AudioClip fenzhi;
    public AudioClip donggui;
    public AudioClip attack;
    public AudioClip tanfan;

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }
    void Update()
    {
     //   if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
            //playDonggui();
        //}
    }

    IEnumerator PlayAudioSequence()
    {
        // 播放开始音频
        audioSource1.clip = startClip;
        audioSource1.volume=1f;
        audioSource1.Play();
        yield return new WaitForSeconds(startClip.length);  // 等待音频播放完

        // 播放 BGM
        audioSource1.clip = bgmClip;
        audioSource1.loop = true;  // 设置循环播放
        audioSource1.volume=0.05f;
        audioSource1.Play();
        
        // 等待游戏结束 (这里你可以加一个触发条件)
        yield return new WaitUntil(() => GameManager.isGameOver);  // 这里假设 GameManager 里有 isGameOver 标志

        // 播放结束音频
        audioSource1.loop = false;  // 关闭循环播放
        audioSource1.clip = endClip;
        audioSource1.volume=1f;
        audioSource1.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScene");
    }
    public void playFenzhi()
    {
        audioSource2.loop=false;
        audioSource2.clip=fenzhi;
        audioSource2.volume=1f;
        audioSource2.Play();
    }
    public void playDonggui()
    {
        audioSource2.loop=false;
        audioSource2.clip=donggui;
        audioSource2.volume=1f;
        audioSource2.Play();
    }

    public void playAttack()
    {
        audioSource3.loop=false;
        audioSource3.clip=attack;
        audioSource3.volume=1f;
        audioSource3.Play();
    }
    public void playTanfan()
    {
        audioSource3.loop=false;
        audioSource3.clip=tanfan;
        audioSource3.volume=1f;
        audioSource3.Play();
    }

}

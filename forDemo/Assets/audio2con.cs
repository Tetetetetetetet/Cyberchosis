using UnityEngine;

public class PlaySoundOnTrigger2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundClip;

    void Start()
    {
        // 给 AudioSource 赋值 AudioClip
        audioSource.clip = soundClip;
    }

    public void play()
    {
        audioSource.Play(); // 播放音频
    }
}
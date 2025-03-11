using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld_music : MonoBehaviour
{
 public AudioSource musicSource; // 音乐播放组件
    public AudioClip musicClip;     // 音乐剪辑
    public float playInterval = 20f; // 播放间隔时间，单位秒
    private float timer = 0f;       // 用于计时的变量

    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.loop = false;
    }

    void Update()
    {
        // 每次调用 Update 的时候，增加 timer 的值
        timer += Time.deltaTime;

        // 当 timer 大于或等于 playInterval 时，播放音乐并重置 timer
        if (timer >= playInterval)
        {
            musicSource.Play();
            timer = 0f; // 重置计时器
        }
    }
}

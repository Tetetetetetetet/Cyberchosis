using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBloodControl : MonoBehaviour
{
    public float damagePerSecond = 1f; // 每秒掉血量
    private CharacterHealth HeroBlood; // 引用 CharacterHealth 脚本

    private float timeSinceLastDamage = 0f; // 上次掉血的时间间隔
    // Start is called before the first frame update
    void Start()
    {
        HeroBlood = GetComponent<CharacterHealth>(); // 获取 CharacterHealth 脚本
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDamage += Time.deltaTime;
        if (timeSinceLastDamage >= 1f)
        {
            HeroBlood.TakeDamage(damagePerSecond);
            timeSinceLastDamage = 0f; // 重置时间间隔
        }        
    }
}

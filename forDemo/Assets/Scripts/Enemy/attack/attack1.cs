using System.Collections;
using UnityEngine;

public class attack : MonoBehaviour
{
    public PolygonCollider2D attack1Collider; // 攻击1的碰撞器
    public PolygonCollider2D attack2Collider; // 攻击2的碰撞器
    public PolygonCollider2D attack3Collider; // 攻击3的碰撞器

    private void Start()
    {
        attack1Collider.enabled = false; // 初始时禁用攻击1的碰撞器
        attack2Collider.enabled = false; // 初始时禁用攻击2的碰撞器
        attack3Collider.enabled = false; // 初始时禁用攻击3的碰撞器
    }

    public void StartAttack1()
    {
        StartCoroutine(Attack1Routine());
    }

    public void StartAttack2()
    {
        StartCoroutine(Attack2Routine());
    }
    public void StartAttack3()
    {
        StartCoroutine(Attack3Routine());
    }

    private IEnumerator Attack3Routine()
    {
        attack3Collider.enabled = true; // 启用攻击3的碰撞器
        yield return new WaitForSeconds(0.33f); // 等待攻击持续时间
        attack3Collider.enabled = false; // 禁用攻击3的碰撞器
    }
    private IEnumerator Attack1Routine()
    {
        attack1Collider.enabled = true; // 启用攻击1的碰撞器
        yield return new WaitForSeconds(0.66f); // 等待攻击持续时间
        attack1Collider.enabled = false; // 禁用攻击1的碰撞器
    }

    private IEnumerator Attack2Routine()
    {
        attack2Collider.enabled = true; // 启用攻击2的碰撞器
        yield return new WaitForSeconds(0.5f); // 等待攻击持续时间
        attack2Collider.enabled = false; // 禁用攻击2的碰撞器
    }
}
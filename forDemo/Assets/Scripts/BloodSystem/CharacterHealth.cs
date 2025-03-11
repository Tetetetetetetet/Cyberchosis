using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float maxHealth = 100f; // 最大血量
    public float currentHealth = 100f; // 当前血量

    // 其他方法，如掉血、加血等
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检测到武器掉落到地面时销毁
        if (collision.CompareTag("Weapon"))
        {
            Destroy(collision.gameObject);
        }
    }
}
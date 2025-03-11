using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Camera mainCamera; // 主相机

    void Start()
    {
        // 获取主相机
        mainCamera = Camera.main;
    }

    void Update()
    {

        // 检查子弹是否在主相机视野外
    }

    bool IsOutsideCameraView()
    {
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewPortPosition.x < 0 || viewPortPosition.x > 1 || viewPortPosition.y < 0 || viewPortPosition.y > 1)
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 如果碰到Hero
        if (other.CompareTag("Player"))
        {
            // 调用Hero的受伤方法
            other.GetComponent<PlayerBehavior>().takeDamage(6f);
            // 销毁子弹
        }
        Destroy(gameObject);
    }
}

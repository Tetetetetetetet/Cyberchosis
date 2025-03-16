using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Camera mainCamera; // 主相机
    private float birthTime;
    public float lifeTime;

    void Start()
    {
        // 获取主相机
        mainCamera = Camera.main;
        birthTime=Time.time;
    }

    void Update()
    {
        // 检查子弹是否在主相机视野外
        if((Time.time-birthTime)>lifeTime)
        {
            Destroy(gameObject);
            return;
        }
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
            Destroy(gameObject);
            // 销毁子弹
        }
        if(other.CompareTag("HeroAttack"))
        {
            Destroy(gameObject);
        }
    }
}

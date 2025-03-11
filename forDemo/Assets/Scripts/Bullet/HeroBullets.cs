using UnityEngine;

public class HeroBulletBehavior : MonoBehaviour
{
    private Camera mainCamera; // 主相机
    public float speed;
    public GameObject mHero;
    void Start()
    {
        // 获取主相机
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 p=transform.localPosition;
        // 检查子弹是否在主相机视野外
        if (IsOutsideCameraView())
        {
            Destroy(gameObject);
        }
        p+=transform.up*(speed*Time.smoothDeltaTime);
        transform.localPosition=p;
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
        if (other.CompareTag("Boss")||other.CompareTag("Enemy"))
        {
            other.GetComponent<BossAttacked>().takeDamage(6f,0);
            Destroy(gameObject);
        }
    }
}


using Unity.VisualScripting;
using UnityEngine;

public class HeroBulletBehavior : MonoBehaviour
{
    private Camera mainCamera; // 主相机
    public float speed;
    public PlayerBehavior mHero; //生成时自动挂载
    public float damage;
    void Start()
    {
        // 获取主相机
        //mHero=util.findGameObject("Hero").GetComponent<PlayerBehavior>();
        mainCamera = Camera.main;
        damage=mHero.remoteDamage;
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
            if(mHero.gm.isBoss)other.GetComponent<Boss1>().takeDamage(damage);
            other.GetComponent<EnemyBehacior>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}


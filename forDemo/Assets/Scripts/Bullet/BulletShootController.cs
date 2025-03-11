using UnityEngine;

public class BulletShootController : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制体
    public float spawnInterval = 1f; // 子弹生成间隔

    public float bulletSpeed = 10f; // 子弹速度

    private float timer = 0f; // 计时器
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 计时器累加
        timer += Time.deltaTime;

        // 如果计时器达到生成间隔，生成子弹
        if (timer >= spawnInterval)
        {
            SpawnBullet();
            timer = 0f; // 重置计时器
        }
    }

    void SpawnBullet()
    {
        // 在指定位置生成子弹
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // 为子弹添加刚体组件（如果不存在）
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = bullet.AddComponent<Rigidbody2D>();
        }        
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * bulletSpeed;

    }
}

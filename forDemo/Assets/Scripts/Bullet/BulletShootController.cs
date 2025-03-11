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

        // 获取或添加刚体组件
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = bullet.AddComponent<Rigidbody2D>();
        }    

        // 找到玩家对象
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // 计算指向玩家的方向（单位向量）
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // 让子弹朝玩家方向移动
            rb.velocity = direction * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("未找到玩家，子弹未能指向玩家！");
        }
    }


}

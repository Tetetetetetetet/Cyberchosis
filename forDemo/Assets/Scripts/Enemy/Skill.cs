using UnityEngine;

public class Skill : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // 武器预制体数组
    public float dropCount=10;  // 每次掉落的武器数量
    public float dropSpeed = 5.0f; // 武器掉落速度
    public float dropRange = 5.0f; // 武器掉落的水平范围

    public bool hasDropped = false; // 标志变量，用于控制是否已经生成过武器

    void Start()
    {
       
    }

    public void skill()
    {
        for (int i = 0; i < dropCount; i++)
        {
            // 随机选择一个武器预制体
            int id=Random.Range(0, weaponPrefabs.Length);
            GameObject weaponPrefab = weaponPrefabs[id];
            Debug.Log($"{id}/{weaponPrefabs.Length}");

            // 在屏幕正上方随机位置生成武器
            Vector3 dropPosition = new Vector3(Random.Range(-dropRange, dropRange), Camera.main.orthographicSize + 1, 0);
            GameObject weaponInstance = Instantiate(weaponPrefab, dropPosition, Quaternion.identity);

            // 设置掉落速度
            Rigidbody2D rb = weaponInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(0, -dropSpeed), ForceMode2D.Impulse);
            }
        }
    }
}

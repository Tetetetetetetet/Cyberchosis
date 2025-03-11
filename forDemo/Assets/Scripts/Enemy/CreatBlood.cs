using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public string bloodbarPrefabPath = "Prefabs/Bloodbar"; // 血条预制体路径
    public GameObject canvas; // UI画布
    public float offsety = 0.5f; // 血条与敌人之间的偏移量
    public float offsetx=0.5f;
    public Text text;

    public GameObject bloodbarInstance; // 实例化的血条对象
    private Slider bloodbarSlider; // 血条滑块
    EnemyBehacior enemy;
    
    void Start()
    {
        // 从 Resources 文件夹加载血条预制体
        GameObject bloodbarPrefab = Resources.Load<GameObject>(bloodbarPrefabPath);
        if (bloodbarPrefab == null)
        {
            Debug.LogError("Bloodbar prefab not found at path: " + bloodbarPrefabPath);
            return;
        }

        // 在 Canvas 下实例化血条预制体
        bloodbarInstance = Instantiate(bloodbarPrefab, canvas.transform);
        bloodbarInstance.name = "EnemyBloodbar";

        // 获取 Slider 组件
        bloodbarSlider = bloodbarInstance.GetComponent<Slider>();
        enemy=GetComponent<EnemyBehacior>();
        if (bloodbarSlider == null)
        {
            Debug.LogError("Slider component not found in Bloodbar prefab!");
            return;
        }

        // 初始化血条位置
        UpdateBloodbarPosition();
        Transform blackground = bloodbarPrefab.transform.Find("Background");
        Transform healthText = blackground.Find("HealthText");
        text = healthText.GetComponent<Text>();

    }

    void Update()
    {
        // 更新血条位置以跟随敌人
        UpdateBloodbarPosition();
        UpdateBloodValue();
        // 更新血条值
    }

    void UpdateBloodbarPosition()
    {
        if (bloodbarInstance != null)
        {
            // 将血条放置在敌人头上
            Vector3 norm=new Vector3 (0,1f,0);
            Vector3 bloodbarPosition = transform.position + transform.up * offsety+norm*offsetx;
            bloodbarInstance.transform.position = bloodbarPosition;

            // 确保血条在相机视野内
            bloodbarInstance.transform.position = Camera.main.WorldToScreenPoint(bloodbarPosition);
            bloodbarInstance.transform.SetParent(canvas.transform, false);
        }
    }
    string UpdateBloodValue()
    {
        float EnemyPercent = enemy.currHealth / enemy.maxHealth;
        bloodbarSlider.value = EnemyPercent;
        text.text = enemy.currHealth.ToString("0") + "/" + enemy.maxHealth.ToString("0");
        if(EnemyPercent<=0f)
        {
            Destroy(bloodbarInstance);
        }
        return text.text;
    }

}
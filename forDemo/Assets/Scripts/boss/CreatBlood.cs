using UnityEngine;
using UnityEngine.UI;

public class CreateBlood : MonoBehaviour
{
    public string bloodbarPrefabPath = "Prefabs/Bloodbar"; // 预制体路径
    public GameObject canvas; // 引用 Canvas

    private GameObject bloodbarInstance; // 实例化的 Bloodbar 对象
    private bloodSystem bloodSystem; // BloodSystem 组件
    private Slider bloodbarSlider; // 血条 Slider

    void Start()
    {
        // 确保 Canvas 存在
        if (canvas == null)
        {
            Debug.LogError("Canvas is not assigned in CreateBlood script!");
            return;
        }

        // 从 Resources 文件夹加载预制体
        GameObject bloodbarPrefab = Resources.Load<GameObject>(bloodbarPrefabPath);
        if (bloodbarPrefab == null)
        {
            Debug.LogError("Bloodbar prefab not found at path: " + bloodbarPrefabPath);
            return;
        }

        // 在 Canvas 下实例化 Bloodbar 预制体
        bloodbarInstance = Instantiate(bloodbarPrefab, canvas.transform);

        // 获取 BloodSystem 组件
        bloodSystem = bloodbarInstance.GetComponentInChildren<bloodSystem>();
        if (bloodSystem == null)
        {
            Debug.LogError("BloodSystem component not found in Bloodbar prefab!");
            return;
        }

        // 获取 Slider 组件
        bloodbarSlider = bloodbarInstance.GetComponentInChildren<Slider>();
        if (bloodbarSlider == null)
        {
            Debug.LogError("Slider component not found in Bloodbar prefab!");
            return;
        }

        // 设置 BloodSystem 的 target 为当前敌人
        bloodSystem.target = this.gameObject;

        // 初始化血条
        UpdateBloodbar();

        // 调整 Bloodbar 的锚点和偏移
        RectTransform bloodbarRectTransform = bloodbarInstance.GetComponent<RectTransform>();
        bloodbarRectTransform.anchorMin = new Vector2(0.5f, 1); // 锚点设置为顶部中心
        bloodbarRectTransform.anchorMax = new Vector2(0.5f, 1);
        bloodbarRectTransform.anchoredPosition = new Vector2(0, -10); // 向下偏移 10 个单位
    }

    private void Update()
    {
        if (bloodbarInstance != null)
        {
            // 计算敌人位置的偏移量
            Vector3 offsetPosition = transform.position + new Vector3(0, 2, 0); // 偏移量设置为 2

            // 将敌人位置从世界空间转换为屏幕空间
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(offsetPosition);

            // 转换为 Canvas 的局部坐标
            RectTransform bloodbarRectTransform = bloodbarInstance.GetComponent<RectTransform>();
            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            Vector2 localPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, Camera.main, out localPosition);

            // 更新 Bloodbar 的位置
            bloodbarRectTransform.anchoredPosition = localPosition;
        }
    }

    // 更新血条的方法
    public void UpdateBloodbar()
    {
        if (bloodbarSlider != null)
        {
            // 假设敌人有一个 CharacterHealth 脚本
            CharacterHealth health = GetComponent<CharacterHealth>();
            if (health != null)
            {
                bloodbarSlider.value = health.currentHealth / health.maxHealth;
            }
        }
    }
}
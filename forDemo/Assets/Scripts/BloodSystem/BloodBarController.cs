using UnityEngine;
using UnityEngine.UI;

public class BloodBarController : MonoBehaviour
{
    public Slider BloodBar;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBloodBarPosition();
    }
    
    public void UpdateBloodBarPosition(){

        Vector3 targetScreenPosition = Camera.main.WorldToScreenPoint(target.transform.position + new Vector3(0f, 1.5f, 0f)); // 调整Y轴偏移量，使血条位于头上
        BloodBar.transform.position = targetScreenPosition;

    }


}

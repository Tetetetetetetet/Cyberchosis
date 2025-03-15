using Unity.VisualScripting;
using UnityEngine;

public class GravitySensor : MonoBehaviour
{
    public float checkInterval = 0.5f; // 检测间隔
    public SkillGravity gravm=null;
    private SkillGravity currentTrap; // 当前影响该物体的陷阱
    private Rigidbody2D rb; // 物体的Rigidbody2D组件
    private float timer = 0f; // 计时器
    public BoxCollider2D myCollider;
    void Start()
    {
        if(GameManager.mGM.mHero.GetComponent<PlayerBehavior>().canSkill2==false)
        {
            this.enabled=false;
        }
        else
        {
            this.enabled=true;
        }
        // 获取物体的Rigidbody2D组件
        gravm=SkillGravity.GravityManager;
        myCollider=GetComponent<BoxCollider2D>();
        Debug.Assert(gravm!=null);
        Debug.Assert(myCollider!=null);
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("GravitySensor requires a Rigidbody2D component.");
        }
    }

    void Update()
    {
        // 定期检测是否在陷阱范围内
        timer += Time.deltaTime;
        if (timer >= checkInterval)
        {
            CheckTraps();
            timer = 0f;
        }
        if(SkillGravity.GravityManager.active==false)
        {
            SkillGravity.GravityManager.ResetGravity(rb);
        }
    }

    void CheckTraps()
    {
        // 获取所有陷阱对象
        SkillGravity[] traps = FindObjectsOfType<SkillGravity>();
        bool flag = false;
        foreach (SkillGravity trap in traps)
        {
            // 检查物体是否在陷阱范围内
            if (transform.position.x >= trap.myCollider.bounds.min.x&& transform.position.x <= trap.myCollider.bounds.max.x )
            {
                // 如果物体不在当前陷阱的影响下，切换到该陷阱
                if (currentTrap != trap)
                {
                    SwitchTrap(trap);
                }
                else{
                    currentTrap.ApplyGravity(rb);
                }
                flag = true;
                Debug.Log("In trap");
                break; // 只受一个陷阱的影响
            }
        }
        if (!flag){
            Debug.Log("Not in trap");
            rb.gravityScale = gravm.postiveGravityScale;
        }
    }

    void SwitchTrap(SkillGravity newTrap)
    {
        // 切换到新的陷阱，并应用重力
        currentTrap = newTrap;
        currentTrap.ApplyGravity(rb);
    }


}

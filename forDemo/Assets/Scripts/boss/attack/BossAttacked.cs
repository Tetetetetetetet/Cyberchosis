using System.Collections;
using UnityEngine;

public class BossAttacked : MonoBehaviour
{
    //手动挂载为Boss对象的组件
    public GameObject theBoss=null;
    public bossBehavior bossbeh;
    public BossControl bossControl;
    public float flash_delta;
    public SpriteRenderer sp;
    public float flash_time;

    // Start is called before the first frame update
    void Start()
    {
        theBoss=gameObject;
        Debug.Assert(theBoss!=null);
        bossbeh=theBoss.GetComponent<bossBehavior>();
        Debug.Assert(bossbeh!=null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - flash_time >= flash_delta) sp.color = Color.white;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    public void takeDamage(float damage,int attackType)
    {
        Debug.Assert(damage>0);
        Debug.Log("boss attacked");
        bossbeh.currHealth -= damage;
        flash(true);
    }

    public void flash(bool isflash)
    {
        Debug.Log("flash start");
        if (isflash)
        {
            Debug.Log($"isflash:{isflash}");
            sp.color = Color.red;
            flash_time = Time.time;
            isflash = !isflash;
        }
        if (Time.time - flash_time >= flash_delta) sp.color = Color.white;
    }

    private IEnumerator FlashColor(Color flashColor, float duration)    
{
    // 保存原始颜色
    Color originalColor = sp.color;

    // 设置闪烁颜色
    sp.color = flashColor;

    // 等待一段时间
    yield return new WaitForSeconds(duration);

    // 恢复原始颜色
    sp.color = originalColor;
}
}

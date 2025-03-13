using UnityEngine;

public class SkillGravity : MonoBehaviour
{
    public bool active;
    public static SkillGravity GravityManager;
    public BoxCollider2D myCollider;
    public float postiveGravityScale;
    public float negtiveGravityScale;
    public SpriteRenderer sp;

    void Awake()
    {
        sp=gameObject.GetComponent<SpriteRenderer>();
        myCollider=gameObject.GetComponent<BoxCollider2D>();
        GravityManager=this;
        Color color=sp.color;
        color.a=0f;
        sp.color=color;
    }
    void Start()
    {
        Debug.Assert(sp!=null);
        Debug.Assert(myCollider!=null);
    }

    public void ApplyGravity(Rigidbody2D rb)
    {
        // 改变物体的重力加速度
        if(active)rb.gravityScale = negtiveGravityScale; // 反向重力
    }

    public void ResetGravity(Rigidbody2D rb)
    {
        // 恢复物体的重力加速度
        rb.gravityScale = postiveGravityScale;
    }
    public void setPos(float centerx)
    {
        Vector3 p=transform.localPosition;
        p.x=centerx;
        transform.localPosition=p;
    }
    public void turn()
    {
        Debug.Log("turn");
        Color color=sp.color;
        if(active==false)
        {
            active=true;
            color.a=1f;
        }
        else{
            color.a=0f;
            active=false;
        }
        sp.color=color;

    }
}

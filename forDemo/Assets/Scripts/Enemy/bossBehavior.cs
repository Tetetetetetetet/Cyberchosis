using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    public GameManager gm;//接口: 自动接唯一的GameManager对象的GameManager组件
    public GameObject mHero; //接口：自动接Player GameObject
    public float maxHealth;
    public float currHealth=100;
    public Animator anim;
    public float jumpspeed=20.0f;
    public Transform boss=null;
    public Rigidbody2D rb=null;
    public float movespeed=5.0f;
    private SpriteRenderer spriteRenderer;
     private float attack_time=2.0f;
      public float flyspeed=2f;
    public float flyforce=10f;

    void Start()
    {
        //自动接口
        if(maxHealth==0)maxHealth=100;//默认值
        currHealth=maxHealth;
        gm=GameManager.mGM;
        mHero=gm.mHero;

        attack_time=Time.time;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
void Update(){
    /*if(gm.gameStart)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (rb.velocity.y == 0 && anim.GetBool("isground"))
        {
            anim.SetBool("isground", true);
        }
        else
        {
            anim.SetBool("isground", false);
        }
    }*/
}
    // Start is called before the first frame update

    public void Run(float direction){
        //改变朝向 
        Vector3 scale=transform.localScale;
        scale.x=-1*direction*Mathf.Abs(scale.x);
        transform.localScale=scale;
        if(anim.GetBool("isground")){
            anim.SetBool("isrun",true);
        }
        boss.Translate(direction*movespeed*Time.smoothDeltaTime*1,0,0);
    }
    public void stopRun(){
        anim.SetBool("isrun",false);
    }
    public void Jump(){
        if(anim.GetBool("isground")){
            anim.SetTrigger("isjump");
            rb.velocity = new Vector2(0, jumpspeed);  
        }
    }
    public void attack(){
        anim.SetTrigger("isattack");
        
    }
    public void die(){
        anim.SetBool("isdead",true);
    }
    public void Fly(float dir){
    anim.SetBool("isfly",true);
    rb.velocity = new Vector2(rb.velocity.x, 0);
    switch(dir){
            case 1: // 向右飞行
                rb.velocity = new Vector2(flyspeed, rb.velocity.y);
                break;
            case -1: // 向左飞行
                rb.velocity = new Vector2(-flyspeed, rb.velocity.y);
                break;
            case 2: // 向上飞行
                rb.velocity = new Vector2(rb.velocity.x, flyspeed);
                break;
            case -2: // 向下飞行
                rb.velocity = new Vector2(rb.velocity.x, -flyspeed);
                break;
            default:
                Debug.LogWarning("Invalid direction value: " + dir);
                break;
        }
}
public void stopFly(){
    anim.SetBool("isfly",false);
}

    public void Flycontrol(){
        if(Input.GetKey(KeyCode.H))
        Fly(-1);
        if(Input.GetKey(KeyCode.J))
        Fly(1);
        if(Input.GetKey(KeyCode.K))
        Fly(-2);
        if(Input.GetKey(KeyCode.L))
        Fly(2);
    }
    private void OnCollisionExit2D(Collision2D collision){
    //anim.SetBool("isground", false);
}
}

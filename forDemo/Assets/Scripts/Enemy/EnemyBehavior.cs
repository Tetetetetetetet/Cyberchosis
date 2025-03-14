using UnityEngine;

public class EnemyBehacior : MonoBehaviour
{
    // Start is called before the first frame update
    //需要定义player的
    public float currHealth = 100;
    public float maxHealth = 100;
    private float attackTimer = 0;
    public float attackInterval = 0;
    public float movespeed = 0;
    private Vector2 start;
    public float range ;//巡逻范围
    Animator anim;
    private bool movingRight = true;
    [SerializeField]
    private float damage;
    private float damageRange;
    private float criticalHitChance;
    public PlayerBehavior mHero;
    public GameManager gm;
    public Drop drop;
    void Start()
    {
        attackTimer=Time.time;
        anim = GetComponent<Animator>();
        start = transform.position;
        damage=Random.Range(damage,damage+damageRange);
        gm=GameObject.Find("GameManager").GetComponent<GameManager>();
        mHero=gm.mHero.GetComponent<PlayerBehavior>();
        drop=GetComponent<Drop>();
        if (Random.value < criticalHitChance)
        {
            // 暴击伤害，例如是普通伤害的两倍
            damage*= 2;
            Debug.Log("Critical hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        if(currHealth<=0){
            anim.SetTrigger("Dead");
            drop.DropSkills();
            Destroy(GetComponent<EnemyHealthBar>().bloodbarInstance);
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy enter trigger");
        if(collision.gameObject.CompareTag("Player"))
        {
           //造成伤害
            if(Time.time-attackTimer>=attackInterval)
            {
                attackTimer=Time.time;
                anim.SetTrigger("attack");
                Debug.Log("attack");
                PlayerBehavior player=collision.gameObject.GetComponent<PlayerBehavior>();
                player.takeDamage(damage);
            }
        }        
    }
    //巡逻
    void patrol(){
        Vector3 targetPos = new Vector3(start.x + range * (movingRight ? 1 : -1), transform.position.y, 0);
        // 判断是否需要改变方向
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            movingRight = !movingRight; // 改变移动方向
            targetPos.x = start.x + range * (movingRight ? 1 : -1);
        }
        // 向目标位置移动
        walktoPos(targetPos);
        }
    void walk(float direction){
            Vector3 scale=transform.localScale;
        scale.x=direction*Mathf.Abs(scale.x);
        transform.localScale=scale;
        transform.Translate(direction*movespeed*Time.smoothDeltaTime*1,0,0);
    }
    void walktoPos(Vector3 pos){
        if(pos.x<transform.position.x){
            walk(-1);
        }
        else if(pos.x>transform.position.x){
            walk(1);
        }
    }

    public void takeDamage(float damage){
        anim.SetTrigger("hit");
        currHealth-=damage;
    }

}
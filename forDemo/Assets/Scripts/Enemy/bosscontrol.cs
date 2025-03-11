using UnityEngine;
public class BossControl : MonoBehaviour
{
    public Skill skill;
    public GameObject target = null;
    public GameManager gm;
    public float lowBattery;
    public BoxCollider2D feet;
    public bool isGround;
    public Rigidbody2D rb; // 修改为 Rigidbody
    public Animator anim;
    public float movespeed = 5.0f;
    public bossBehavior boss;
    public float range = 1.0f;
    public bool findtarget = false;
    private float timer;
    private float Dir;
    private float updateDelta = 10f;
    private float startingX;
    public float delta = 0.5f;//距离差
    public float alpha = 5f;//boss视野
    private float attack_time;
    public float attack_delt = 5.0f;

    public string mode;
    void Start()
    {
        gm = GameManager.mGM;
        // 尝试获取 Rigidbody 组件
        feet = boss.GetComponent<BoxCollider2D>();
        mode = "AI";
        startingX = boss.transform.position.x;
        timer = Time.time;
        Dir = Random.Range(-1.0f, 1.0f);

        // 检查组件是否存在
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing on the game object: " + gameObject.name);
        }
        if (target == null)
        {
            Debug.LogError("Target is not assigned!");
            return;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (mode)
            {
                case "AI":
                    mode = "keyboard";
                    break;
                case "Keyboard":
                    mode = "AI";
                    break;
            }
        }
        findtarget = intarget();
        Debug.Log(findtarget);
        if (findtarget)
        {
            movetotarget();
        }
        else
            boss.stopRun();
        if (boss.currHealth == 0)
        {
            boss.die();
        }
        //else
        //Patrol();
        // boss.stopRun();
        if (mode == "Keyboard")
        {
            if (Input.GetKey(KeyCode.D))
            {
                boss.Run(1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                boss.Run(-1);

            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                boss.stopRun();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                boss.Jump();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                boss.attack();

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isdead", true);
            }

        }
        boss.Flycontrol();
        if (Input.GetKeyDown(KeyCode.P) && !skill.hasDropped)
        {
            Debug.Log("start drop");
            skill.skill();
            skill.hasDropped = true; // 设置标志为 true，防止再次触发
        }

        //hongxue(lowBattery);
        Debug.Log($"{boss.currHealth}");
        if(boss.currHealth<=0)
        {
            boss.die();
            gm.win();
        }
        /*
        else{       
        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // 检测是否与地面碰撞（假设地面的标签为 "Ground"）
        if (collision.gameObject.CompareTag("ground"))
        {
            // 停止物体的运动
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            anim.SetBool("isground", true);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            boss.stopRun();
            anim.SetBool("isrun", false);
            if (Time.time - timer >= attack_delt)
            {
                boss.attack();
                timer = Time.time;
            }
        }
        if (collision.collider is PolygonCollider2D)
        {

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            anim.SetBool("isground", true);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - timer >= attack_delt)
            {
                boss.attack();
                timer = Time.time;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            anim.SetBool("isground", false);
    }
    public void Patrol()
    {
        boss.Run(Dir);
        // 如果 Boss 到达巡逻范围的边界，切换方向
        if ((Dir > 0 && transform.position.x >= range + startingX) ||
            (Dir < 0 && transform.position.x <= startingX - range))
        {
            Dir *= -1; // 切换方向
        }
        Vector3 moveDirection = new Vector3(Dir * movespeed * Time.deltaTime, 0, 0);

        // 更新 Boss 的位置
        transform.position += moveDirection;
    }
    public void movetotarget()
    {
        if (target.transform.position.x + delta < transform.position.x)
        {
            boss.Run(-1);
        }
        else if (target.transform.position.x - delta > transform.position.x)
        {
            boss.Run(1);
        }
    }
    public bool intarget()
    {
        if (target.transform.position.x > transform.position.x + alpha || target.transform.position.x < transform.position.x - alpha)
            return false;
        else
            return true;
    }

   // public void hongxue(float value)
    //{
        //if (boss.currHealth <= value&&skill.hasDropped==false)
        //{
            //skill.skill();
            //skill.hasDropped = true; // 设置标志为 true，防止再次触发
        //}
    //}

}


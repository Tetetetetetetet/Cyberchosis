using UnityEngine;

public class KnightMove : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D mHeroPhysics;
    [SerializeField] private float mSpeed = 3f;
    bool jump=false;
    // Start is called before the first frame update
    void Start()
    {
        mHeroPhysics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float d = mSpeed * Time.smoothDeltaTime;

        Vector2 older = mHeroPhysics.velocity;
        if (Input.GetKey(KeyCode.A))
        {
            mHeroPhysics.velocity = new Vector2(-mSpeed, older.y);
            // Note: this is updating the position (no physics)
        }

        if (Input.GetKey(KeyCode.D)) {
                mHeroPhysics.velocity = new Vector2(mSpeed, older.y);
                // Note: this is changing velocity
        }

        // if (Input.GetKey(KeyCode.W)) {
        //     transform.localPosition += new Vector3(0, d, 0);
        //         // Note: this is updating the position (no physics)
        // }

        if (Input.GetKeyDown(KeyCode.W)) {
            mHeroPhysics.velocity = new Vector2(older.x, 2*mSpeed);
                // Note: this is changing velocity
                
               // animator.SetTrigger("Jump");
            // if(jump==false)
            // {
            //     Debug.Log("set");
            // jump=true;}
        }
        // Vector2 x=mHeroPhysics.velocity;
        // animator.SetFloat("AirSpeedY",x.y);
        // if(x.y<0&&jump==true)
        // {
        //     jump=false;
        //     Debug.Log("reset");
        //     animator.ResetTrigger("Jump");
        // }

    }
    /*

    void OnCollisionEnter2D(Collision2D other) {
        // Note: the Hero's Collider.isTriggered is OFF
        //   When this is off, will collide with all Collider2D with isTriggered Off
        Debug.Log("Hero CollisionEnter:" + other.gameObject.name);
    }

    void OnCollisionStay2D(Collision2D other) {
        Debug.Log("Hero CollisionStay:" + other.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D other) {
        Debug.Log("Hero CollisionExit:" + other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hero TriggerEnter:" + other.gameObject.name);
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Hero TriggerStay:" + other.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Hero TriggerExit:" + other.gameObject.name);
    }
    */
}

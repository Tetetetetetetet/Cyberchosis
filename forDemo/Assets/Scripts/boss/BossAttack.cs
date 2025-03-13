using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public PolygonCollider2D mycollider;
    public GameObject theBoss;
    public float damage;
    public Animator anim;
    void Start()
    {
        mycollider=GetComponent<PolygonCollider2D>();
        mycollider.enabled=false;
        theBoss=GameManager.mGM.Boss;
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void on()
    {
        mycollider.enabled=true;
    }
    public void off()
    {
        mycollider.enabled=false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))other.gameObject.GetComponent<PlayerBehavior>().takeDamage(damage);
    }
    //public  void onFrameEnter()
    //{
        //Debug.Log("onFrameEnter");
        //mycollider.enabled=true;
        //StartCoroutine(disableHitbox());
    //}
    private IEnumerator disableHitbox()
    {
        yield return new WaitForSeconds(0.1f);
        mycollider.enabled=false;
    }
    //public void onFrameExit()
    //{
        //Debug.Log("onFrameExit");
        //mycollider.enabled=false;
    //}
    //public void finishAttack()
    //{
        //theBoss.GetComponent<Boss1>().isAttacking=false;
    //}
}

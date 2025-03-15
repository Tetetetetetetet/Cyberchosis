using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroSwordBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public PolygonCollider2D sword=null;
    public GameObject mHero=null;
    public float damage=0;

    void Start()
    {
        sword=gameObject.GetComponent<PolygonCollider2D>();
        mHero=PlayerBehavior.mHero;
        damage=mHero.GetComponent<PlayerBehavior>().damage;

        Debug.Assert(sword!=null);
        Debug.Assert(mHero!=null);
        Debug.Assert(damage!=0);

        sword.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Boss"))
        {
            Debug.Log("hero attack boss");
            other.GetComponent<Boss1>().takeDamage(damage);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(other.GetComponent<EnemyBehavior>()!=null)other.GetComponent<EnemyBehavior>().takeDamage(damage);
        }
        else if(other.GetComponent<EnemyClass>()!=null)other.GetComponent<EnemyClass>().takeDamage(damage);
    }
}

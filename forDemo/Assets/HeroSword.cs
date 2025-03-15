using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class HeroSwordBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public PolygonCollider2D sword=null;
    public GameObject mHero=null;
    public float damage;
    public AudioController aco;

    void Start()
    {
        sword=gameObject.GetComponent<PolygonCollider2D>();
        mHero=PlayerBehavior.mHero;
        damage=mHero.GetComponent<PlayerBehavior>().damage;
        Debug.Assert(sword!=null);
        Debug.Assert(mHero!=null);
        Debug.Assert(damage!=0);
        Debug.Assert(aco!=null);

        sword.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        damage=mHero.GetComponent<PlayerBehavior>().damage;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Boss"))
        {
            Debug.Log("hero attack boss");
            if(other.GetComponent<Boss1>()!=null)
            {
                other.GetComponent<Boss1>().takeDamage(damage);
                aco.playAttack();
            }
            else
            {
                other.GetComponent<BossBehavior>().takeDamage(damage);
                aco.playAttack();
            }
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(other.GetComponent<EnemyBehavior>()!=null)other.GetComponent<EnemyBehavior>().takeDamage(damage);
            aco.playAttack();
        }
        else if(other.GetComponent<EnemyClass>()!=null)
        {
            other.GetComponent<EnemyClass>().takeDamage(damage);
            aco.playAttack();
        }

    }
}

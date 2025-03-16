using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    // Start is called before the first frame update
    public float currHealth;
    public float maxHealth;
    public float damage;
    public Rigidbody2D myRigid;
    public GameManager gm;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void takeDamage(float damage)
    {
        currHealth-=damage;
        if(currHealth<=0)
        {
            Destroy(gameObject);
        }
    }
}

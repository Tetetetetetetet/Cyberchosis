using UnityEngine;

abstract public class EnemyBehavior : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    // Start is called before the first frame update
    public void takeDamage(float damage)
    {
        currHealth-=damage;
    }
    void Start()
    {
        currHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

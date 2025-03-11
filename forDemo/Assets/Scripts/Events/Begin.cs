using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void firstattack(){
        GameObject cell=GameObject.Find("cell");
        GameObject Enemy = Resources.Load<GameObject>("Prefabs/Character/Enemy1");
        EnemyBehacior e = Enemy.GetComponent<EnemyBehacior>();
        e.range=5f;
        EnemyHealthBar b=Enemy.GetComponent<EnemyHealthBar>();
        b.canvas=GameObject.Find("Dialogue UI");
        Enemy.transform.localScale = new Vector3(2.5f, 2.5f,0);
        Destroy(cell);
        Vector3 position = new Vector3(6f, -4f, 0); // 实例化位置
        Instantiate(Enemy, position, Quaternion.identity);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isAttack : MonoBehaviour
{
    PolygonCollider2D p;
    // Start is called before the first frame update
    void Start()
    {
        p=GameObject.Find("isDamage").GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void close(){
        p.enabled=false;
    }
    public void open(){
        p.enabled=true;
    }
}

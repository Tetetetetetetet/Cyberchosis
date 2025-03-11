using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAngryPig : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject e;
    void Start()
    {
        e = Instantiate(Resources.Load("Prefabs/AngryPig") as GameObject);
        Vector3 p;
        p.y=-20.9f;
        p.z=0.0f;
        p.x=Random.Range(-40,20);
        e.transform.localPosition=p;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

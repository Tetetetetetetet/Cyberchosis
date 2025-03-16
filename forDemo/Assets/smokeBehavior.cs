using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime;
    private float birthTime;
    void Start()
    {
        birthTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.time-birthTime)>lifeTime)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}

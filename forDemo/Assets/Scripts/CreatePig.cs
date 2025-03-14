using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePig : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isActive;
    public int maxPigNum;
    void Start()
    {
        isActive=false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("MakePig");
        //perform once
        if(isActive)
        {
            GameObject e=this.gameObject;
            Vector3 p=e.transform.localPosition;
            MakePigBoss.Pig(p.x,maxPigNum);
            isActive=false;
        }
    }
     
}


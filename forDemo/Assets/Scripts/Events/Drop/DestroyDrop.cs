using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framuu
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
     if(other.gameObject.CompareTag("Player")){
        if(Input.GetKey(KeyCode.S)){
            Destroy(gameObject);
        }
     }   
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
        if(Input.GetKey(KeyCode.S)){
            Destroy(gameObject);
        }
     }   
    }

}

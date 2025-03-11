using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour
{
    [SerializeField]
    private float damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            PlayerBehavior player=other.gameObject.GetComponent<PlayerBehavior>();
            player.takeDamage(damage);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            PlayerBehavior player=other.gameObject.GetComponent<PlayerBehavior>();
            player.takeDamage(damage);
        }
    }
}

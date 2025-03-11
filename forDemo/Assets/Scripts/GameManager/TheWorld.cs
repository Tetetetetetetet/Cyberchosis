using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TheWorld : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string nextSence;
    void Start()
    {
        nextSence="LifeFog";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(nextSence);
        }
    }
}

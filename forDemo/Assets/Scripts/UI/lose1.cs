using UnityEngine;
using UnityEngine.SceneManagement;
public class lose1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
              SceneManager.LoadScene("Start Scene");
        }
        
    }
}

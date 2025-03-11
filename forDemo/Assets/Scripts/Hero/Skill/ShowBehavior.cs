using UnityEngine;

public class ShowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int order=0;
    void Start()
    {
        
    }

    GameObject childObject;
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Transform childTransform = transform.Find("Wallbig");
            if (childTransform != null)
            {
                childObject = childTransform.gameObject;
                Debug.Log("Found child GameObject: " + childObject.name);
            if(order==2)
            {
                
                ShowClass.Show(childObject,0);
                order=0;

            }
            else{
                ShowClass.Show(childObject,2);
                order=2;
            }
            }
            GameObject my=this.gameObject;
            if(order==2)
                MyComponent.AbleBox2D(my);
            else MyComponent.DisableBox2D(my);
        }
    }
}

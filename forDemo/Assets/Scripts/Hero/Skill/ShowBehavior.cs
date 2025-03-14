using UnityEngine;

public class ShowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int order=0;
    public bool onSignal;
    public bool isActive;
    void Start()
    {
        onSignal=false;
        isActive=false;
    }

    GameObject childObject;
    // Update is called once per frame
    void Update()
    {
        
        //if(Input.GetKeyDown(KeyCode.Y))
        if(onSignal==true&&isActive==false)
        {
            isActive=true;
            Showup();
        }
            // Transform childTransform = transform.Find("Wallbig");
            // if (childTransform != null)
            // {
            //     childObject = childTransform.gameObject;
            //     //Debug.Log("Found child GameObject: " + childObject.name);
            // if(order==2)
            // {
                
            //     ShowClass.Show(childObject,0);
            //     order=0;

            // }
            // else{
            //     ShowClass.Show(childObject,2);
            //     order=2;
            // }
            // }
            // GameObject my=this.gameObject;
            // if(order==2)
            //     MyComponent.AbleBox2D(my);
            // else MyComponent.DisableBox2D(my);
            //Invoke("Showdown",2.0f);
    }
    public void Showup()
    {
        Debug.Log("wall showup");
        Transform childTransform = transform.Find("Wallbig");
            if (childTransform != null)
            {
                
                childObject = childTransform.gameObject;
                ShowClass.Show(childObject,2);
                GameObject my=this.gameObject;
                MyComponent.AbleBox2D(my);
            }
    }
    public void Showdown()
    {
        Debug.Log("wall showdown");
        Transform childTransform = transform.Find("Wallbig");
            if (childTransform != null)
            {
                childObject = childTransform.gameObject;
                ShowClass.Show(childObject,0);
                GameObject my=this.gameObject;
                MyComponent.DisableBox2D(my);
            }
    }
}

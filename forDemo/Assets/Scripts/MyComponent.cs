using UnityEngine;

public class MyComponent
{
    // Start is called before the first frame update
    public static void AbleBox2D(GameObject e)
    {
        BoxCollider2D boxCollider = e.GetComponent<BoxCollider2D>();
        boxCollider.enabled=true;

    }
    public static void DisableBox2D(GameObject e)
    {
        BoxCollider2D boxCollider = e.GetComponent<BoxCollider2D>();
        boxCollider.enabled=false;
    }
}

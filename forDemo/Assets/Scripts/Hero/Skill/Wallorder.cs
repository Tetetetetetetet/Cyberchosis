using UnityEngine;

public class Wallorder : MonoBehaviour
{
    public float ordertime;
    public int wantorder=0;
    // Start is called before the first frame update
    void Start()
    {
        ordertime=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(wantorder==0)
            wantorder=2;
            else wantorder=0;

        }
        if(ordertime>0)
        {
            ordertime-=Time.deltaTime;

        }
        else 
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = wantorder;
        }
    }
    }
    // public void OnTriggerEnter2D(Collider2D obj)
    // {
    //     SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    // if (spriteRenderer != null)
    // {
    //     // 根据条件动态修改 Order in Layer
    //     spriteRenderer.sortingOrder = 6;
    //     ordertime=2.0f;
    // }
    // }
    public void OnTriggerEnter2D(Collider2D obj)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = 2;
        ordertime=2.0f;
    }
    }
    public void OnTriggerStay2D(Collider2D obj)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = 2;
        ordertime=2.0f;
    }
    }
    public void OnTriggerExit2D(Collider2D obj)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = wantorder;
        ordertime=0.0f;
    }
    }
    // public void OnCollisionEnter2D(Collision2D obj)
    // {

    //     SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    // if (spriteRenderer != null)
    // {
    //     // 根据条件动态修改 Order in Layer
    //     spriteRenderer.sortingOrder = 6;
    //     ordertime=2.0f;
    // }
    // }
    public void OnTriggerEnter2D(Collision2D obj)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = 2;
        ordertime=2.0f;
    }
    }
     public void OnCollisionStay2D(Collision2D obj)
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = 2;
        ordertime=2.0f;
    }
    }
    public void OnCollisionExit2D(Collision2D obj)
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = wantorder;
        ordertime=0.0f;
    }
    }
}


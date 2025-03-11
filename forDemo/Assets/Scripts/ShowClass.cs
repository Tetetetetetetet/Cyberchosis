using UnityEngine;

public class ShowClass
{
    public static void Show(GameObject e,int wantorder)
    {
        SpriteRenderer spriteRenderer = e.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
        // 根据条件动态修改 Order in Layer
        spriteRenderer.sortingOrder = wantorder;
        }
    }
}

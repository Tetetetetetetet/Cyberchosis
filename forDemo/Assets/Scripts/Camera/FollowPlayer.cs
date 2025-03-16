using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hero; // 英雄的 Transform
    public float edgeThreshold = 0.2f; // 屏幕边缘的阈值（0 到 1 之间）
    public float moveSpeed = 5.0f; // 相机移动速度
    public Vector3 offset; // 相机与英雄的偏移量

    private Vector3 targetPosition; // 相机的目标位置
    private Vector3 velocity = Vector3.zero; // 平滑移动的缓存速度

    void Update()
    {
        // 计算英雄在屏幕空间中的位置（0 到 1）
        Vector3 screenPos = Camera.main.WorldToViewportPoint(hero.position);

        // 检测英雄是否接近屏幕边缘
        bool isNearEdge = screenPos.x < edgeThreshold || screenPos.x > 1 - edgeThreshold ||
                          screenPos.y < edgeThreshold || screenPos.y > 1 - edgeThreshold;

        if (isNearEdge)
        {
            // 如果英雄接近边缘，更新相机的目标位置
            targetPosition = hero.position + offset;
        }

        // 平滑移动相机到目标位置
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, moveSpeed);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 目标对象（玩家）
    public float smoothing = 5f; // 平滑速度

    private Vector3 offset; // 摄像机与目标的偏移量

    void Start()
    {
        // 计算初始偏移量
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // 计算目标位置
        Vector3 targetCamPos = target.position + offset;
        // 平滑地移动摄像机到目标位置
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

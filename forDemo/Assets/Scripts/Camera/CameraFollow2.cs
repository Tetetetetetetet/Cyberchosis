using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    // Start is called before the first frame update
public Transform target; // 要跟随的目标
    public float followSpeed = 5.0f; // 跟随速度
    public Vector3 offset; // 相机与目标之间的偏移量

    void Update()
    {
        // 使用 Lerp 来平滑相机移动
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // 确保相机的旋转不会改变
        transform.LookAt(target);
    }
}

using Cinemachine;
using UnityEngine;
using System.Collections;
public class CameraFoucus1 : MonoBehaviour
{
  public Camera mainCamera; // 主相机
    public Vector3 targetPosition; // 相机移动的目标位置
    public float moveDuration = 1.0f; // 平移持续时间
    public float stayDuration = 2.0f; // 停留持续时间

    private Vector3 originalPosition; // 相机原始位置

    private void Start()
    {
        // 保存主相机的原始位置
        originalPosition = mainCamera.transform.position;
    }

    // 调用此函数触发相机移动
    public void MoveCameraToTarget()
    {
        // 平滑移动到目标位置
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, moveDuration);

        // 延迟停留时间后返回原始位置
        Invoke("ReturnToOriginalPosition", stayDuration);
    }

    // 返回原始位置
    private void ReturnToOriginalPosition()
    {
        // 平滑返回原始位置
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, originalPosition, moveDuration);

        // 取消所有延迟调用，确保不会重复触发
        CancelInvoke();
    }
}

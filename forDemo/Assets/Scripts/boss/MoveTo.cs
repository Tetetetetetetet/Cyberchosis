using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Rigidbody2D rb; // 物体的刚体
    public Vector2 targetPosition; // 目标位置
    public float speed; // 移动速度
    public bool isMoving = false; // 是否正在移动
    public bool stay;
    public float moveRatio;
    public float leftDis;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        isMoving=false;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    public void StartMoving(Vector3 newTarget)
    {
        if(isMoving==false)
        {
            targetPosition = newTarget;
            isMoving = true;
        }
    }

    public void MoveTowardsTarget()
    {
        Vector2 direction = (targetPosition - rb.position).normalized; // 计算方向
        float step = speed * Time.fixedDeltaTime; // 计算本帧移动的步长
        //Vector2 newPosition = rb.position + direction * step; // 计算新位置
        Vector2 newPosition=Vector2.Lerp(rb.position,targetPosition,moveRatio);
        leftDis=Vector3.Distance(rb.position, targetPosition);


        // 如果快要到达目标，直接设为目标点
        if ( leftDis< 1f)
        {
            newPosition = targetPosition;
            if(stay==false)isMoving = false; // 停止移动
        }

        rb.MovePosition(newPosition); // 移动刚体
    }
}

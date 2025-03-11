using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroller : MonoBehaviour
{
public Animator animator;
    public float moveSpeed = 5.0f;
    private float moveInput;

    void Update()
    {
        // 获取水平输入
        moveInput = Input.GetAxis("Horizontal");

        // 更新动画状态
        if (moveInput != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        // 检查是否按下攻击键
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("Attack1", true);
        }
        else
        {
            animator.SetBool("Attack1", false);
        }

        // 控制角色移动
        if(Input.GetKeyDown("d") || Input.GetKey(KeyCode.RightArrow))
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
    }
}

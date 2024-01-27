using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // 玩家角色的Transform
    public float rotationSpeed = 5f; // 摄像机旋转的速度
    public Vector2 rotationRange = new Vector2(-30, 30); // 围绕Y轴的旋转范围
    public float damping = 0.15f; // 阻尼效果
    private float currentRotation = 0f; // 当前旋转角度
    private Vector3 offset; // 摄像机相对于玩家的偏移量
    private Vector3 velocity = Vector3.zero; // 用于SmoothDamp的速度

    void Start()
    {
        // 计算初始偏移量
        offset = transform.position - player.position;
    }

    void Update()
    {
        // 摄像机始终看向玩家
        transform.LookAt(player);

        // 当按住鼠标中键时，根据鼠标水平移动距离旋转摄像机
        if (Input.GetMouseButton(2)) // 鼠标中键
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentRotation += mouseX * rotationSpeed;
            currentRotation = Mathf.Clamp(currentRotation, rotationRange.x, rotationRange.y);
        }

        // 更新摄像机位置
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        Vector3 targetPosition = player.position + rotation * offset;

        // 应用阻尼效果
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}

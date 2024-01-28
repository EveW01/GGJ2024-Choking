using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionBehaviour : MonoBehaviour
{
    public Rigidbody handColliderRigidbody; // 手部的 Rigidbody
    public Rigidbody playerRigidbody; // 玩家的 Rigidbody
    public float speedThreshold = 5f; // 速度阈值
    public float forceMagnitude = 10f; // 施加的力的大小



    void OnCollisionEnter(Collision collision)
    {
        // 检查是否与标记为 'Default' 的物体发生碰撞
        if (collision.gameObject.CompareTag("Environment"))
        {
            Debug.Log("Speed:" + handColliderRigidbody.velocity.magnitude);

            // 检查手部的移动速度
            if (handColliderRigidbody.velocity.magnitude > speedThreshold)
            {
                // 计算力的方向（碰撞点的法线方向）
                Vector3 forceDirection = collision.contacts[0].normal;

                // 向玩家刚体施加力
                playerRigidbody.AddForce(-forceDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootColliderDetector : MonoBehaviour
{
    public bool isCollideWithGround = false;

    void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞的对象是否为地面
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isCollideWithGround = true;
            Debug.Log("踢到地了");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // 检查碰撞的对象是否为地面
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isCollideWithGround = true;
            Debug.Log("踢到地了");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 当不再与地面碰撞时
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isCollideWithGround = false;
        }
    }
}

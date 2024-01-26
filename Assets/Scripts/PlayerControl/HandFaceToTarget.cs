using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFaceToTarget : MonoBehaviour
{
    public Transform handTarget; // 目标对象

    void Update()
    {
        // 确保目标对象已被指定
        if (handTarget != null)
        {
            // 使当前GameObject始终朝向handTarget
            transform.LookAt(handTarget);

            // 打印当前GameObject的旋转角度
            //Debug.Log("Current Rotation: " + transform.rotation.eulerAngles);
        }
    }
}

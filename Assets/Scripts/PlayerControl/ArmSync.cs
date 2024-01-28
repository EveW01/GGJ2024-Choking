using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSync : MonoBehaviour
{
    public GameObject syncTarget; // 同步目标对象

    void FixedUpdate()
    {
        if (syncTarget != null)
        {
            // 获取目标对象的本地坐标
            Vector3 targetPosition = syncTarget.transform.position;

            // 设置当前对象的本地坐标
            transform.position = new Vector3(transform.position.x, targetPosition.y, targetPosition.z);
        }
    }
}

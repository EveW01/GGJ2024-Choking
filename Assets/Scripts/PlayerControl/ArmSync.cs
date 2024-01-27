using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSync : MonoBehaviour
{
    public GameObject syncTarget; // 同步目标对象

    void Update()
    {
        if (syncTarget != null)
        {
            // 获取目标对象的本地坐标
            Vector3 targetLocalPosition = syncTarget.transform.localPosition;

            // 设置当前对象的本地坐标
            transform.localPosition = new Vector3(transform.localPosition.x, targetLocalPosition.y, targetLocalPosition.z);
        }
    }
}

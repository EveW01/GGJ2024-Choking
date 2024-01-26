using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPositionFix : MonoBehaviour
{
    void FixedUpdate()
    {
        // 锁定旋转
        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(currentRotation.x, 0, 0);

        // 锁定X轴位置
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(0, currentPosition.y, currentPosition.z);
    }
}

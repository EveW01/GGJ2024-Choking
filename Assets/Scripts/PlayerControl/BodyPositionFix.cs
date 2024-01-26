using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPositionFix : MonoBehaviour
{
    void FixedUpdate()
    {
        // ������ת
        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(currentRotation.x, 0, 0);

        // ����X��λ��
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(0, currentPosition.y, currentPosition.z);
    }
}

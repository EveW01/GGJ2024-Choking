using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPositionFix : MonoBehaviour
{
    public float maxAngularVelocity = 1.0f; // 最大角速度

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on " + gameObject.name);
        }
    }

    void LateUpdate()
    {
        // 锁定旋转
        //Quaternion lockedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        Quaternion lockedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        transform.rotation = lockedRotation;

        // 锁定 X 轴位置
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(0, currentPosition.y, currentPosition.z);
        
    }
}

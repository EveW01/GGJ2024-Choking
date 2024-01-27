using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPositionFix : MonoBehaviour
{
    public bool lockRotation;
    public bool lockPosition;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (lockRotation)
            {
                // ������ת
                //Quaternion lockedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
                Quaternion lockedRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                transform.rotation = lockedRotation;
            }

            if (lockPosition)
            {
                // ����X��λ��
                Vector3 currentPosition = transform.position;
                transform.position = new Vector3(0, currentPosition.y, currentPosition.z);
            }
        }
    }
}

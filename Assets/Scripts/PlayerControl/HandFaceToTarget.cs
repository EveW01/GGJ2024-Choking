using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFaceToTarget : MonoBehaviour
{
    public Transform handTarget; // Ŀ�����

    void Update()
    {
        // ȷ��Ŀ������ѱ�ָ��
        if (handTarget != null)
        {
            // ʹ��ǰGameObjectʼ�ճ���handTarget
            transform.LookAt(handTarget);

            // ��ӡ��ǰGameObject����ת�Ƕ�
            //Debug.Log("Current Rotation: " + transform.rotation.eulerAngles);
        }
    }
}

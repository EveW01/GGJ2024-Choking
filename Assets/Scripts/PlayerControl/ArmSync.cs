using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSync : MonoBehaviour
{
    public GameObject syncTarget; // ͬ��Ŀ�����

    void FixedUpdate()
    {
        if (syncTarget != null)
        {
            // ��ȡĿ�����ı�������
            Vector3 targetPosition = syncTarget.transform.position;

            // ���õ�ǰ����ı�������
            transform.position = new Vector3(transform.position.x, targetPosition.y, targetPosition.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSync : MonoBehaviour
{
    public GameObject syncTarget; // ͬ��Ŀ�����

    void Update()
    {
        if (syncTarget != null)
        {
            // ��ȡĿ��������������
            Vector3 targetPosition = syncTarget.transform.position;

            // ���õ�ǰ�������������
            transform.position = new Vector3(-targetPosition.x, targetPosition.y, targetPosition.z);
        }
    }
}

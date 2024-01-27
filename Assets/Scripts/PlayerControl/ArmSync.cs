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
            // ��ȡĿ�����ı�������
            Vector3 targetLocalPosition = syncTarget.transform.localPosition;

            // ���õ�ǰ����ı�������
            transform.localPosition = new Vector3(transform.localPosition.x, targetLocalPosition.y, targetLocalPosition.z);
        }
    }
}

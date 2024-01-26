using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootColliderDetector : MonoBehaviour
{
    public bool isCollideWithGround = false;

    void OnCollisionEnter(Collision collision)
    {
        // �����ײ�Ķ����Ƿ�Ϊ����
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isCollideWithGround = true;
            Debug.Log("�ߵ�����");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // �����ײ�Ķ����Ƿ�Ϊ����
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isCollideWithGround = true;
            Debug.Log("�ߵ�����");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // �������������ײʱ
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isCollideWithGround = false;
        }
    }
}

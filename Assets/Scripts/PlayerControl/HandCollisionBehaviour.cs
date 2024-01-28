using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionBehaviour : MonoBehaviour
{
    public Rigidbody handColliderRigidbody; // �ֲ��� Rigidbody
    public Rigidbody playerRigidbody; // ��ҵ� Rigidbody
    public const float speedThreshold = 3f; // �ٶ���ֵ
    public float forceMagnitude = 10f; // ʩ�ӵ����Ĵ�С



    void OnCollisionEnter(Collision collision)
    {
        // ����Ƿ�����Ϊ 'Default' �����巢����ײ
        if (collision.gameObject.CompareTag("Environment"))
        {


            // ����ֲ����ƶ��ٶ�
            if (handColliderRigidbody.velocity.magnitude > speedThreshold)
            {
                // �������ķ�����ײ��ķ��߷���
                Vector3 forceDirection = collision.contacts[0].normal;

                // ����Ҹ���ʩ����
                playerRigidbody.AddForce(-forceDirection * forceMagnitude, ForceMode.Impulse);

                Debug.Log("Arm Force Added");
            }
        }
    }
}

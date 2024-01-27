using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToParent : MonoBehaviour
{
    public GameObject parentObject; // Ҫ��Ϊ���Ӷ���ĸ� GameObject

    void Start()
    {
        // ����Ƿ�ָ���˸�����
        if (parentObject != null)
        {
            // ����ǰ GameObject ����Ϊ parentObject ���Ӷ���
            transform.SetParent(parentObject.transform);
        }
        else
        {
            Debug.LogError("Parent object not assigned for " + gameObject.name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // ��ȡ�������
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // ʹ��ǰGameObjectʼ���泯�����
            transform.LookAt(mainCamera.transform);
        }
    }
}

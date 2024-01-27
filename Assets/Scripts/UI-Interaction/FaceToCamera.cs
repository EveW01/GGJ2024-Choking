using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // 获取主摄像机
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // 使当前GameObject始终面朝摄像机
            transform.LookAt(mainCamera.transform);
        }
    }
}

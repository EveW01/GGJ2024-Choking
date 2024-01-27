using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToParent : MonoBehaviour
{
    public GameObject parentObject; // 要成为其子对象的父 GameObject

    void Start()
    {
        // 检查是否指定了父对象
        if (parentObject != null)
        {
            // 将当前 GameObject 设置为 parentObject 的子对象
            transform.SetParent(parentObject.transform);
        }
        else
        {
            Debug.LogError("Parent object not assigned for " + gameObject.name);
        }
    }
}

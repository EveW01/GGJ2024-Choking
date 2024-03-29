using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableHandTarget : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 originalLocalPosition;

    [Header("UI提示")]
    public Image dragHintCircle;
    public Sprite normalHint;
    public Sprite highlightHint;

    void Start()
    {
        // 保存初始本地位置
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        if (IsMouseOver())
        {
            dragHintCircle.sprite = highlightHint;
        }
        else
        {
            dragHintCircle.sprite = normalHint;
        }



        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(0) && IsMouseOver())
        {
            StartDragging();

            dragHintCircle.color = Color.green;
        }

        // 当鼠标左键被按住时，更新位置
        if (isDragging)
        {
            DragObject();
        }

        // 检测鼠标左键释放
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            StopDragging();

            dragHintCircle.color = Color.white;
        }
    }

    private bool IsMouseOver()
    {
        // 射线检测以确定鼠标是否在对象的Collider范围内
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject;
    }

    private void StartDragging()
    {
        isDragging = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void DragObject()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
        transform.position = new Vector3(transform.position.x, cursorPosition.y, cursorPosition.z);
    }

    private void StopDragging()
    {
        isDragging = false;
        // 重置到初始本地位置
        transform.localPosition = originalLocalPosition;
    }
}

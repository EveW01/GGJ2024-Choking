using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableHandTarget : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 originalLocalPosition;

    void Start()
    {
        // �����ʼ����λ��
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        // �������������
        if (Input.GetMouseButtonDown(0) && IsMouseOver())
        {
            StartDragging();
        }

        // ������������סʱ������λ��
        if (isDragging)
        {
            DragObject();
        }

        // ����������ͷ�
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            StopDragging();
        }
    }

    private bool IsMouseOver()
    {
        // ���߼����ȷ������Ƿ��ڶ����Collider��Χ��
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
        // ���õ���ʼ����λ��
        transform.localPosition = originalLocalPosition;
    }
}

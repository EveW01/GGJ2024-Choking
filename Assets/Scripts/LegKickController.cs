using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKickController : MonoBehaviour
{
    public GameObject startPositionObject; // 提供起始位置的空GameObject
    public float moveDuration = 1.0f; // 移动持续时间
    private Vector3 startPosition;
    private Vector3 endPosition = Vector3.zero; // 目标位置（相对于父物体的本地坐标）
    private bool isMoving = false; // 移动标志

    void Start()
    {
        // 确保提供了起始位置对象
        if (startPositionObject != null)
        {
            startPosition = startPositionObject.transform.localPosition;
            StartCoroutine(MoveToPosition(startPosition));
        }
        else
        {
            Debug.LogError("Start position object is not assigned.");
        }
    }

    void Update()
    {
        // 检测鼠标右键按下
        if (Input.GetMouseButtonDown(1) && !isMoving)
        {
            StartCoroutine(MoveToPosition(endPosition));
        }

        // 检测鼠标右键释放
        if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine(MoveToPosition(startPosition));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 originalPosition = transform.localPosition;

        while (elapsedTime < moveDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;
        isMoving = false;
    }
}

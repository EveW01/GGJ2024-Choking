using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKickController : MonoBehaviour
{
    public GameObject startPositionObject; // �ṩ��ʼλ�õĿ�GameObject
    public float moveDuration = 1.0f; // �ƶ�����ʱ��
    private Vector3 startPosition;
    private Vector3 endPosition = Vector3.zero; // Ŀ��λ�ã�����ڸ�����ı������꣩
    private bool isMoving = false; // �ƶ���־

    void Start()
    {
        // ȷ���ṩ����ʼλ�ö���
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
        // �������Ҽ�����
        if (Input.GetMouseButtonDown(1) && !isMoving)
        {
            StartCoroutine(MoveToPosition(endPosition));
        }

        // �������Ҽ��ͷ�
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

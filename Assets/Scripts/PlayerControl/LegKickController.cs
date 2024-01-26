using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKickController : MonoBehaviour
{
    public GameObject startPositionObject; // �ṩ��ʼλ�õĿ�GameObject
    public float moveDuration = 0.06f; // �ƶ�����ʱ��
    public Rigidbody playerRigidbody; // ��ҽ�ɫ��Rigidbody
    public float kickForce = 10f; // ����ʩ�ӵ���
    private Vector3 startPosition;
    private Vector3 endPosition = Vector3.zero; // Ŀ��λ��
    private bool isMoving = false; // �ƶ���־

    public float checkRadius = 0.5f; // �������İ뾶
    public LayerMask defaultLayerMask; // Default���LayerMask

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
        bool isKicking = targetPosition == endPosition; // �ж��Ƿ�Ϊ���ȶ���

        while (elapsedTime < moveDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;

        // ����ǵ��ȶ������ҽŲ�����淢����ײ
        if (isKicking && IsFootCollidingWithDefaultLayer())
        {
            // ����ҽ�ɫʩ�����ϵ���
            playerRigidbody.AddForce(Vector3.up * kickForce, ForceMode.Impulse);
            Debug.Log("������");
        }

        isMoving = false;
    }

    private bool IsFootCollidingWithDefaultLayer()
    {
        // ���Ų�Collider�Ƿ���Default������巢����ײ
        Vector3 footPosition = transform.position; // ����Ų�λ��Ϊ��ǰGameObject��λ��
        return Physics.CheckSphere(footPosition, checkRadius, defaultLayerMask);
    }
}

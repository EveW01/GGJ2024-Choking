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

    public Transform forceDirectionSkeleton; // 参考人体骨骼的Transform

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
        bool hasAppliedForce = false; // �Ƿ��Ѿ�ʩ�ӹ���

        while (elapsedTime < moveDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;

            if (isKicking && !hasAppliedForce && IsFootCollidingWithDefaultLayer())
            {
                // 计算力的方向
                Vector3 forceDirection = forceDirectionSkeleton.forward; // 使用骨骼的前方向作为力的方向

                // 给玩家角色施加力
                playerRigidbody.AddForce(forceDirection * kickForce, ForceMode.Impulse);
                //Debug.Log("弹射了");
                hasAppliedForce = true; // 标记已经施加过力
            }


            yield return null;
        }

        transform.localPosition = targetPosition;
        isMoving = false;
    }

    private bool IsFootCollidingWithDefaultLayer()
    {
        // ���Ų�Collider�Ƿ���Default������巢����ײ
        Vector3 footPosition = transform.position; // ����Ų�λ��Ϊ��ǰGameObject��λ��
        return Physics.CheckSphere(footPosition, checkRadius, defaultLayerMask);
    }

    void OnDrawGizmos()
    {
        // ���� Gizmo ��ɫ
        Gizmos.color = Color.yellow;

        // ����Ų�λ��Ϊ��ǰGameObject��λ��
        Vector3 footPosition = transform.position;

        // ����һ����������ʾ CheckSphere �ķ�Χ
        Gizmos.DrawWireSphere(footPosition, checkRadius);
    }
}

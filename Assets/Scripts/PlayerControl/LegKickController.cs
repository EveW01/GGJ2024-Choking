using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKickController : MonoBehaviour
{
    public GameObject startPositionObject; // 提供起始位置的空GameObject
    public float moveDuration = 0.06f; // 移动持续时间
    public Rigidbody playerRigidbody; // 玩家角色的Rigidbody
    public float kickForce = 10f; // 蹬腿施加的力
    private Vector3 startPosition;
    private Vector3 endPosition = Vector3.zero; // 目标位置
    private bool isMoving = false; // 移动标志

    public float checkRadius = 0.5f; // 检测球体的半径
    public LayerMask defaultLayerMask; // Default层的LayerMask

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
        bool isKicking = targetPosition == endPosition; // 判断是否为蹬腿动作
        bool hasAppliedForce = false; // 是否已经施加过力

        while (elapsedTime < moveDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;

            // 如果是蹬腿动作并且脚部与地面发生碰撞，且尚未施加过力
            if (isKicking && !hasAppliedForce && IsFootCollidingWithDefaultLayer())
            {
                // 给玩家角色施加向上的力
                playerRigidbody.AddForce(Vector3.up * kickForce, ForceMode.Impulse);
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
        // 检测脚部Collider是否与Default层的物体发生碰撞
        Vector3 footPosition = transform.position; // 假设脚部位置为当前GameObject的位置
        return Physics.CheckSphere(footPosition, checkRadius, defaultLayerMask);
    }

    void OnDrawGizmos()
    {
        // 设置 Gizmo 颜色
        Gizmos.color = Color.yellow;

        // 假设脚部位置为当前GameObject的位置
        Vector3 footPosition = transform.position;

        // 绘制一个球体来表示 CheckSphere 的范围
        Gizmos.DrawWireSphere(footPosition, checkRadius);
    }
}

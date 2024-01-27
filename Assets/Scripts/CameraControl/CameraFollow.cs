using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ��ҽ�ɫ��Transform
    public float rotationSpeed = 5f; // �������ת���ٶ�
    public Vector2 rotationRange = new Vector2(-30, 30); // Χ��Y�����ת��Χ
    public float damping = 0.15f; // ����Ч��
    private float currentRotation = 0f; // ��ǰ��ת�Ƕ�
    private Vector3 offset; // ������������ҵ�ƫ����
    private Vector3 velocity = Vector3.zero; // ����SmoothDamp���ٶ�

    void Start()
    {
        // �����ʼƫ����
        offset = transform.position - player.position;
    }

    void Update()
    {
        // �����ʼ�տ������
        transform.LookAt(player);

        // ����ס����м�ʱ���������ˮƽ�ƶ�������ת�����
        if (Input.GetMouseButton(2)) // ����м�
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentRotation += mouseX * rotationSpeed;
            currentRotation = Mathf.Clamp(currentRotation, rotationRange.x, rotationRange.y);
        }

        // ���������λ��
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        Vector3 targetPosition = player.position + rotation * offset;

        // Ӧ������Ч��
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}

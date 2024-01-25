using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBack : MonoBehaviour
{
    public float swipeSpeed = 5.0f;
    public float smoothTime = 0.3f; // �ε巯�� �̵��� ���� �ð�
    public float minX = -25f; // x ��ǥ�� �ּҰ�
    public float maxX = 35f; // x ��ǥ�� �ִ밪
    public ParticleSystem clickEffect; // Ŭ�� �� ����� ����Ʈ

    private Vector2 touchStartPos;
    private Vector3 velocity = Vector3.zero; // �̵� �ӵ��� �����ϴ� ����

    void Update()
    {
        // ȭ�� Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // Ŭ�� ���� ��ġ ���
            touchStartPos = Input.mousePosition;

            // Ŭ�� ����Ʈ ���
            if (clickEffect != null)
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = 0;
                Instantiate(clickEffect, clickPosition, Quaternion.identity);
            }
        }

        // ȭ�� ��ġ �Է� ����
        if (Input.GetMouseButton(0))
        {
            // �������� �Ÿ� ���
            float swipeDistance = Input.mousePosition.x - touchStartPos.x;

            // ����� �ε巴�� �¿�� ��������
            float targetX = transform.position.x + swipeDistance * swipeSpeed * Time.deltaTime;
            targetX = Mathf.Clamp(targetX, minX, maxX); // x ��ǥ�� ���� ����

            // �ε巯�� �̵� ����
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), ref velocity, smoothTime);

            // ���� ��ġ�� ���� �������� ���� ��ġ�� ������Ʈ
            touchStartPos = Input.mousePosition;
        }
    }

}

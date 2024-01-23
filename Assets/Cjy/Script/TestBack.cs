using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBack : MonoBehaviour
{
    public float swipeSpeed = 5.0f;
    public ParticleSystem clickEffect; // Ŭ�� �� ����� ����Ʈ

    private Vector2 touchStartPos;

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

            // ����� �¿�� ��������
            transform.Translate(Vector3.right * swipeDistance * swipeSpeed * Time.deltaTime);

            // ���� ��ġ�� ���� �������� ���� ��ġ�� ������Ʈ
            touchStartPos = Input.mousePosition;

            // ȭ�� ���� �������� �� �������� ����
            if (Mathf.Abs(transform.position.x) >= 29f && Mathf.Abs(transform.position.x) <= -29f) // ���÷� x��ǥ�� 5.0f �̻��̸� ����
            {
                transform.position = new Vector3(Mathf.Sign(transform.position.x) * 5.0f, transform.position.y, transform.position.z);
            }
        }
    }
}

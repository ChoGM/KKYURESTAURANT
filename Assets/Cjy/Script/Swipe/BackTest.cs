using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSwipe : MonoBehaviour
{
    private Vector3 touchStart;
    private float zDistance;
    private float minX = -29f;  // x ��ǥ�� �ּҰ�
    private float maxX = 29f;   // x ��ǥ�� �ִ밪

    void Start()
    {
        zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        // ȭ�� Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // Ŭ�� ���� ��ġ ���
            if (IsMouseInAllowedArea(Input.mousePosition))
            {
                touchStart = GetWorldPositionOnPlane(Input.mousePosition, zDistance);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // ȭ�� ��ġ �Է� ����
            if (IsMouseInAllowedArea(Input.mousePosition))
            {
                // �������� �Ÿ� ���
                Vector3 direction = touchStart - GetWorldPositionOnPlane(Input.mousePosition, zDistance);
                direction.y = 0f; // y�� �̵� ����

                // ����� �ε巴�� �¿�� ��������
                Camera.main.transform.position += direction;

                // x ��ǥ�� ���� ����
                Vector3 newPosition = Camera.main.transform.position + direction;
                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

                // �ε巯�� �̵� ����
                Camera.main.transform.position = newPosition;

                // ���� ��ġ�� ���� �������� ���� ��ġ�� ������Ʈ
                touchStart = GetWorldPositionOnPlane(Input.mousePosition, zDistance);
            }
        }
    }

    bool IsMouseInAllowedArea(Vector3 mousePosition)
    {
        Vector3 worldPosition = GetWorldPositionOnPlane(mousePosition, zDistance);

        // Ư�� ��ġ(��: y��ǥ�� -3.5 �̸��� ���)���� �巡�׸� ����
        if (worldPosition.y < -3.2f)
        {
            return false;
        }

        // ������ ������ �巡�׸� ���
        return true;
    }

    Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.up, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}

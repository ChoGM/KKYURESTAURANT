using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    private Vector3 startDragPosition;
    private Rect selectionBox;

    void Update()
    {
        HandleSelectionInput();
    }

    void HandleSelectionInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �巡�� ���� ��ġ ����
            startDragPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            // �巡�� �ڽ� ũ�� ���
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 lowerLeft = Vector3.Min(startDragPosition, currentMousePosition);
            Vector3 upperRight = Vector3.Max(startDragPosition, currentMousePosition);
            selectionBox = Rect.MinMaxRect(lowerLeft.x, lowerLeft.y, upperRight.x, upperRight.y);

            // �巡�� �ڽ��� �ð������� ǥ��
            DrawSelectionBox(selectionBox);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // �巡�װ� ������ �� ���õ� ���� ó��
            HandleSelectedUnits();
        }
    }

    void DrawSelectionBox(Rect box)
    {
        // GUI.Box ���� ����Ͽ� �巡�� �ڽ��� �ð������� ǥ��
        GUI.Box(box, "");
    }

    void HandleSelectedUnits()
    {
        // �巡�� �ڽ��� ���Ե� ��� ������ ����
        Collider2D[] colliders = Physics2D.OverlapAreaAll(selectionBox.min, selectionBox.max);

        foreach (Collider2D collider in colliders)
        {
            // ���õ� ���ֿ� ���� �߰� ������ ���⿡ �߰�
            Debug.Log("Selected Unit: " + collider.gameObject.name);
        }
    }
}

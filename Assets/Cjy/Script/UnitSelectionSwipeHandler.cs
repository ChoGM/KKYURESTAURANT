using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSelectionSwipeHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform unitSelectionRectTransform;
    private Vector2 startPosition;
    private bool isDragging = false;

    void Start()
    {
        // ���� ����â�� RectTransform ������Ʈ ��������
        unitSelectionRectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �ٸ� ĵ���������� �̺�Ʈ�� �����ϵ��� üũ
        if (!IsPointerOverUIObject(eventData.position, eventData.pressEventCamera))
        {
            return;
        }

        // �巡�� ���� �� �ʱ� ��ġ ����
        startPosition = unitSelectionRectTransform.anchoredPosition;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return;
        }

        // ���������� �Ÿ� ���
        Vector2 dragDelta = eventData.delta;

        // ���� ����â �̵�
        unitSelectionRectTransform.anchoredPosition += dragDelta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�� ���� �� �ʱ� ��ġ�� �ǵ�����
        unitSelectionRectTransform.anchoredPosition = startPosition;
        isDragging = false;
    }

    // �ٸ� ĵ�������� UI �̺�Ʈ�� �����ϱ� ���� �޼���
    private bool IsPointerOverUIObject(Vector2 touchPosition, Camera eventCamera)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    // �ٸ� ��ũ��Ʈ���� ���� �������� ������ Ȯ���ϱ� ���� �޼���
    public bool IsDragging()
    {
        return isDragging;
    }
}

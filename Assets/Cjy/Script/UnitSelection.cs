using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    // ��ư�� ����� ������ ������ �迭 �Ǵ� ����Ʈ
    public GameObject[] unitButtons;

    void Start()
    {
    }

    void SelectUnit(int unitIndex)
    {
        // ���⿡�� ���õ� ���ֿ� ���� �߰� ó���� �����ϸ� �˴ϴ�.
        GameObject selectedUnit = unitButtons[unitIndex];

        Debug.Log("Selected Unit: " + selectedUnit.name);
    }
}

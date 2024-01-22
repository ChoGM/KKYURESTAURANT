using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallUnit : MonoBehaviour
{
    // ���� �����յ��� ������ ������
    public GameObject unitPrefab1;
    public GameObject unitPrefab2;
    public GameObject unitPrefab3;
    public GameObject unitPrefab4;

    public GameObject Shop;

    // ���õ� ������ ������ ����
    private GameObject selectedUnitPrefab;

    // �������� ��ȯ�� ��ġ
    public Vector2 spawnPosition;

    void Update()
    {
        // ���õ� ���ο� ���� ��ȯ ��ġ ����
        if (DataMgr.instance.currentLine == Line.Line1)
        {
            spawnPosition = new Vector2(-35f, 1f);
        }
        else if (DataMgr.instance.currentLine == Line.Line2)
        {
            spawnPosition = new Vector2(-35f, -0.8f);
        }
        else if (DataMgr.instance.currentLine == Line.Line3)
        {
            spawnPosition = new Vector2(-35f, -2.6f);
        }
    }

    // ��ư�� Ŭ���� �� ���õ� ������ ����
    public void OnClickButten1()
    {
        selectedUnitPrefab = unitPrefab1;
        Debug.Log("���� 1");
    }

    public void OnClickButten2()
    {
        selectedUnitPrefab = unitPrefab2;
        Debug.Log("���� 2");
    }

    public void OnClickButten3()
    {
        selectedUnitPrefab = unitPrefab3;
        Debug.Log("���� 3");
    }

    public void OnClickButten4()
    {
        selectedUnitPrefab = unitPrefab4;
        Debug.Log("���� 4");
    }

    // ������ Ŭ���� �� ���õ� ������ ��ȯ
    public void Call()
    {
        Update();

        // ���õ� ������ �ִٸ� ��ȯ
        if (selectedUnitPrefab != null && (Shop.GetComponent<Shop>().CoinInt > 0f))
        {
            GameObject unit = Instantiate(selectedUnitPrefab, spawnPosition, Quaternion.identity);
            
            Shop.GetComponent<Shop>().lostMoney();
            selectedUnitPrefab = null;
        }
        else
        {
            Debug.LogWarning("������ ���õ��� �ʾҽ��ϴ�. ��ȯ�ϱ� ���� ������ �������ּ���.");
        }

    }
}

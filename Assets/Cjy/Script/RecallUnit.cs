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

    private int cloneCounter = 0;

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
        Shop.GetComponent<Shop>().UnitCoin = 100f;
        Debug.Log("���� 1");
    }

    public void OnClickButten2()
    {
        selectedUnitPrefab = unitPrefab2;
        Shop.GetComponent<Shop>().UnitCoin = 200f;
        Debug.Log("���� 2");
    }

    public void OnClickButten3()
    {
        selectedUnitPrefab = unitPrefab3;
        Shop.GetComponent<Shop>().UnitCoin = 300f;
        Debug.Log("���� 3");
    }

    public void OnClickButten4()
    {
        selectedUnitPrefab = unitPrefab4;
        Shop.GetComponent<Shop>().UnitCoin = 400f;
        Debug.Log("���� 4");
    }

    // ������ Ŭ���� �� ���õ� ������ ��ȯ
    public void Call()
    {
        Update();

        // ���õ� ������ �ִٸ� ��ȯ
        if (selectedUnitPrefab != null && (Shop.GetComponent<Shop>().CoinInt >= Shop.GetComponent<Shop>().UnitCoin))
        {
            GameObject unit = Instantiate(selectedUnitPrefab, spawnPosition, Quaternion.identity);

            // �������� ������ ��ȣ�� �ٿ��� �̸� ����
            cloneCounter++;
            unit.name = selectedUnitPrefab.name + "_Clone" + cloneCounter;

            Shop.GetComponent<Shop>().lostMoney();

            selectedUnitPrefab = null;
        }
        else
        {
            Debug.LogWarning("������ ���õ��� �ʾҽ��ϴ�. ��ȯ�ϱ� ���� ������ �������ּ���.");
        }

    }
}

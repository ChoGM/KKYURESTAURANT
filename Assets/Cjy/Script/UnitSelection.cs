using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public GameObject unitPrefab; // ��ȯ�� ���� ������
    public KeyCode summonKey = KeyCode.S; // ��ȯ�� Ű
    public Transform spawnArea; // ��ȯ ����
    public Vector2 fixedSpawnPosition; // ������ ��ȯ ��ġ

    void Update()
    {
        // Ư�� Ű�� ������ �� ���� ��ȯ
        if (Input.GetKeyDown(summonKey))
        {
            SummonUnit();
        }
    }

    void SummonUnit()
    {
        // ���õ� ������Ʈ�� ��ǥ�� �������� ��ȯ ��ġ�� ����
        Vector3 spawnPosition = spawnArea.position;

        // ������ ��ȯ ��ġ�� ���
        spawnPosition += new Vector3(fixedSpawnPosition.x, fixedSpawnPosition.y, 0f);

        Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
    }
}

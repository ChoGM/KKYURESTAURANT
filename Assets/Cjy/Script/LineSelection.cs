using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class LineSelection  : MonoBehaviour
{
    public GameObject unitPrefab; // ������ ������

    void OnMouseDown()
    {
        // ���콺 Ŭ���� �����Ǹ� ������ ��ȯ
        SpawnUnit();
    }

    void SpawnUnit()
    {
        //Ư�� ������Ʈ���� ���� ��ȯ�ϸ鼭 x�� ��ġ�� ����
        float fixedXPosition = -36f; // ������ x�� ��ġ
        Vector3 spawnPosition = new Vector3(fixedXPosition, transform.position.y, transform.position.z);

        // ���⿡���� ������ ���ο� ������ Ư�� ������Ʈ�� ��ġ�� ����
        Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
    }
}

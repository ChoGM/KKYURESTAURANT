using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    private float moveSpeed;
    private float speed;
    private float rangeUnit;   // ������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3.0f;
        speed = 0;
        rangeUnit = 5.0f;      // ������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit�� ������ �ִ� ��� ������Ʈ�� ã��
        EnemyInit[] closeUnits = FindObjectsOfType<EnemyInit>();

        // Set the default speed
        speed = moveSpeed;

        foreach (EnemyInit unit in closeUnits)
        {
            // ���� ���ְ� �� ���� �Ÿ��� ���
            float distanceX = Mathf.Abs(transform.position.x - unit.transform.position.x);
            float distanceY = Mathf.Abs(transform.position.y - unit.transform.position.y);

            // X �� �Ÿ��� ��Ÿ� �̳��̰� Y �� �Ÿ��� 0�� ���� �ӵ��� 0���� ����
            if (distanceX <= rangeUnit && Mathf.Approximately(distanceY, 0))
            {
                speed = 0;
            }
        }

        // Move the unit based on the calculated speed
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
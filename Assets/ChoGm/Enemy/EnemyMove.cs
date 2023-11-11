using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UnitMove�� ��ũ��Ʈ �ּ� ����
public class EnemyMove : MonoBehaviour
{
    private float moveSpeed;
    private float speed;
    private float rangeEnemy;   // ������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.0f;
        speed = 0;
        rangeEnemy = 3.0f;      // ������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit�� ������ �ִ� ��� ������Ʈ�� ã��
        UnitInit[] closeUnits = FindObjectsOfType<UnitInit>();

        // Set the default speed
        speed = moveSpeed;

        foreach (UnitInit unit in closeUnits)
        {
            // ���� ���ְ� �� ���� �Ÿ��� ���
            float distanceX = Mathf.Abs(transform.position.x - unit.transform.position.x);
            float distanceY = Mathf.Abs(transform.position.y - unit.transform.position.y);

            // X �� �Ÿ��� ��Ÿ� �̳��̰� Y �� �Ÿ��� 0�� ���� �ӵ��� 0���� ����
            if (distanceX <= rangeEnemy && Mathf.Approximately(distanceY, 0))
            {
                speed = 0;
            }
        }

        // Move the unit based on the calculated speed
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
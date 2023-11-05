using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    private float moveSpeed;
    private float speed;
    private float rangeUnit;   //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.0f;
        speed = 0;
        rangeUnit = 6.5f;      //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit�� ������ �ִ� ��� ������Ʈ�� ã��
        EnemyInit floatCloseEnemy = GameObject.FindObjectOfType<EnemyInit>();

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistanceX = Mathf.Abs(transform.position.x - floatCloseEnemy.transform.position.x);
        float closeDistanceY = Mathf.Abs(transform.position.y - floatCloseEnemy.transform.position.y);

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� �̵�
        if (closeDistanceX <= rangeUnit)
        {
            speed = 0.0f;
        }
        if (closeDistanceX >= rangeUnit)
        {
            speed = moveSpeed;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

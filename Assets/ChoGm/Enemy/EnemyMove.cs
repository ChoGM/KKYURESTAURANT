using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UnitMove�� ��ũ��Ʈ �ּ� ����
public class EnemyMove : MonoBehaviour
{
    private float moveSpeed;
    private float speed;
    private float rangeEnemy;   //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3.0f;
        speed = 0;
        rangeEnemy = 3.0f;      //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit�� ������ �ִ� ��� ������Ʈ�� ã��
        UnitInit floatCloseUnit = GameObject.FindObjectOfType<UnitInit>();

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistanceX = Mathf.Abs(transform.position.x - floatCloseUnit.transform.position.x);
        float closeDistanceY = Mathf.Abs(transform.position.y - floatCloseUnit.transform.position.y);

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� �̵�
        if (closeDistanceX <= rangeEnemy)
        {
            speed = 0;
        }
        if (closeDistanceX >= rangeEnemy)
        {
            speed = -moveSpeed;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

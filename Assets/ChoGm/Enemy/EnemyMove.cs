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
        moveSpeed = 2.5f;
        speed = 0;
        rangeEnemy = 1.1f;      //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit�� ������ �ִ� ��� ������Ʈ�� ã��
        UnitInit floatCloseUnit = GameObject.FindObjectOfType<UnitInit>();

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistance = Vector3.Distance(transform.position, floatCloseUnit.transform.position);

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� �̵�
        if (closeDistance <= rangeEnemy)
        {
            speed = 0;
        }
        if (closeDistance >= rangeEnemy)
        {
            speed = -moveSpeed;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

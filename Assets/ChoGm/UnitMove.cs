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
        moveSpeed = 4.0f;
        speed = 0;
        rangeUnit = 6.5f;      //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit�� ������ �ִ� ��� ������Ʈ�� ã��
        EnemyInit floatCloseEnemy = GameObject.FindObjectOfType <EnemyInit> ();

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

        //EnemyInit�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� �̵�
        if (closeDistance <= rangeUnit)
        {
            speed = 0;
        }
        if (closeDistance >= rangeUnit)
        {
            speed = moveSpeed;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

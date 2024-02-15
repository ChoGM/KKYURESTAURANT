using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UnitMove�� ��ũ��Ʈ �ּ� ����
public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public float speed;
    public float rangeEnemy;   // ������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        speed = 0;   // ������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
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
            if (speed <= 0.01)
            {
                animator.SetBool("Walk", false);
            }
        }


        if (speed <= 0.01)
        {
            animator.SetBool("Walk", false);
        }
        if (speed > 0.1)
        {
            animator.SetBool("Walk", true);
        }

        // Move the unit based on the calculated speed
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
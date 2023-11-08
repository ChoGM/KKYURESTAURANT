using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_short_atk : MonoBehaviour
{
    public float AT_sp_e;      // ���ݼӵ�
    public float range_e;      // ���� �Ÿ�

    public int num;       // ���ֵ� �� ��ȣ�� �Ű� ��� �������� �Ǻ� ����

    private bool attack;
    private float my_at_sp;

    // Start is called before the first frame update
    void Start()
    {
        my_at_sp = 0.0f;

        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        my_at_sp += Time.deltaTime;     // ���ݼӵ� ������ ���

        ability floatCloseEnemy = GameObject.FindObjectOfType<ability>();

        //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

        //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� ���� ���� ���� ����
        if (closeDistance <= range_e)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack == true && my_at_sp >= AT_sp_e)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
        {
            FindTarget();
            my_at_sp = 0.0f;
        }
    }

    private void FindTarget()
    {
        ability[] enemies = GameObject.FindObjectsOfType<ability>();
        float closestDistance = float.MaxValue;
        ability closestEnemy = null;

        foreach (ability enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        // closestEnemy�� ���� ����� ������Ʈ�� ����˴ϴ�.

        ability closestAbilityComponent = closestEnemy.GetComponent<ability>();
        if (closestAbilityComponent != null)
        {
            closestAbilityComponent.short_hurt(num);
        }


    }
}
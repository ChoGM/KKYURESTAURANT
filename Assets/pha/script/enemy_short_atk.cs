using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_short_atk : MonoBehaviour
{
    public float AT_sp_e;      // ���ݼӵ�
    public float range_e;      // ���� �Ÿ�

    public int num;       // ���ֵ� �� ��ȣ�� �Ű� ��� �������� �Ǻ� ����

    private bool attack;
    private float e_at_sp;

    // Start is called before the first frame update
    void Start()
    {
        e_at_sp = 0.0f;

        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        e_at_sp += Time.deltaTime;     // ���ݼӵ� ������ ���

        ability floatCloseEnemy1 = GameObject.FindObjectOfType<ability>();

        //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistance1 = Vector3.Distance(transform.position, floatCloseEnemy1.transform.position);

        //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� ���� ���� ���� ����
        if (closeDistance1 <= range_e)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack == true && e_at_sp >= AT_sp_e)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
        {
            FindTarget1();
            e_at_sp = 0.0f;
        }
    }

    private void FindTarget1()
    {
        ability[] enemies = GameObject.FindObjectsOfType<ability>();
        float closestDistance1 = float.MaxValue;
        ability closestEnemy1 = null;

        foreach (ability enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance1)
            {
                closestDistance1 = distance;
                closestEnemy1 = enemy;
            }
        }
        // closestEnemy�� ���� ����� ������Ʈ�� ����˴ϴ�.

        ability closestAbilityComponent = closestEnemy1.GetComponent<ability>();
        if (closestAbilityComponent != null)
        {
            closestAbilityComponent.short_hurt(num);
        }


    }
}
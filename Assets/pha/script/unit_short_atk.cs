using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_short_atk : MonoBehaviour
{
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�
    
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

        ability_enemy floatCloseEnemy = GameObject.FindObjectOfType<ability_enemy>();

        //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
        float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

        //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� ���� ���� ���� ����
        if (closeDistance <= range)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack == true && my_at_sp >= AT_sp)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
        {
            FindTarget();
            my_at_sp = 0.0f;
        }

    }

    private void FindTarget()
    {
        ability_enemy[] enemies = GameObject.FindObjectsOfType<ability_enemy>();
        float closestDistance = float.MaxValue;
        ability_enemy closestEnemy = null;

        foreach (ability_enemy enemy in enemies)
        {
            // ���� ���ְ� ���� ���� �Ÿ��� ���
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // �������� �Ÿ��� ��������� �ּ� �Ÿ����� �۴ٸ� ������Ʈ
            if (distance < closestDistance)
            {
                // �߰�: ���� ���� ��ġ���� Ȯ��
                if (Mathf.Approximately(transform.position.y, enemy.transform.position.y))
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        // closestEnemy�� ���� ����� ������Ʈ�� ����˴ϴ�.

        // closestEnemy�� null�� �ƴϸ鼭 ability_enemy ������Ʈ�� ������ �ִ��� Ȯ��
        ability_enemy closestAbilityComponent = closestEnemy?.GetComponent<ability_enemy>();
        if (closestAbilityComponent != null)
        {
            closestAbilityComponent.short_hurt(num);
        }
    }

}

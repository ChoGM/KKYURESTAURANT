using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_short_atk : MonoBehaviour
{
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�
    public float ATK_S;


    private bool attack;
    private float my_at_sp;

    Animator animator;
    Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        my_at_sp = 0.0f;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        my_at_sp += Time.deltaTime; // ���ݼӵ� ������ ���


        Ability_enemy[] enemies = GameObject.FindObjectsOfType<Ability_enemy>();

        // ��� ���� ���� �ݺ�
        foreach (Ability_enemy enemy in enemies)
        {
            // �߰�: ���� ���� ��ġ���� Ȯ��
            if (Mathf.Approximately(transform.position.y, enemy.transform.position.y))
            {
                // �ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
                float closeDistance = Vector3.Distance(transform.position, enemy.transform.position);

                //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� ���� ���� ���� ����
                if (closeDistance <= range)
                {
                    attack = true;
                    animator.SetBool("Attack", true);
                    this.enemy = enemy.transform;
                    if (enemy != null && my_at_sp >= AT_sp)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
                    {
                        Debug.Log("�ܰŸ� ����");
                        enemy.short_hurt(ATK_S);
                        my_at_sp = 0.0f;

                        break;
                    }
                }
                else
                {
                    attack = false;
                    animator.SetBool("Attack", false);
                }

            }

        }
        


    }
}

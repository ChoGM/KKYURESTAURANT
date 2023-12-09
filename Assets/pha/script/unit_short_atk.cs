using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_short_atk : MonoBehaviour
{
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�
    public int num;          // ���ֵ� �� ��ȣ�� �Ű� ��� �������� �Ǻ� ����

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


        ability_enemy[] enemies = GameObject.FindObjectsOfType<ability_enemy>();

        // ��� ���� ���� �ݺ�
        foreach (ability_enemy enemy in enemies)
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
                    if (enemy != null&&my_at_sp >= AT_sp)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
                    {
                        enemy.short_hurt(num);
                        Debug.Log("�Ʊ� ����!");
                    }
                    break;
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

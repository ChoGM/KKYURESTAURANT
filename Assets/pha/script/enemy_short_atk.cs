using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_short_atk : MonoBehaviour
{
    public float AT_sp_e;      // ���ݼӵ�
    public float range_e;      // ���� �Ÿ�
    public float ATK_S_e;


    private bool attack;
    private float my_at_sp;

    Animator animator;
    Transform floatCloseEnemy; // Ÿ���� Transform���� ����

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

      

        Ability[] floatCloseEnemies = GameObject.FindObjectsOfType<Ability>();

        // ��� ���� ���� �ݺ�
        foreach (Ability floatCloseEnemy in floatCloseEnemies)
        {
            // �߰�: ���� ���� ��ġ���� Ȯ��
            if (Mathf.Approximately(transform.position.y, floatCloseEnemy.transform.position.y))
            {
                // �ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���
                float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

                //�ش� ��ũ��Ʈ�� ������ �ִ� ������Ʈ���� �Ÿ��� ���� ��Ÿ��� ���� ���� ���� ���� ����
                if (closeDistance <= range_e)
                {
                    attack = true;
                    animator.SetBool("Attack", true);
                    this.floatCloseEnemy = floatCloseEnemy.transform; // floatCloseEnemy�� Transform �Ҵ�
                    if (attack && my_at_sp >= AT_sp_e)
                    {
                        floatCloseEnemy.short_hurt(ATK_S_e);
                        my_at_sp = 0.0f;

                    }
                    break; // �̹� �ϳ��� ���ֿ� ���� ������ �����Ǿ����Ƿ� ������ �����մϴ�.
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

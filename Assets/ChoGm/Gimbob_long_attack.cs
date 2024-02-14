using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimbob_long_attack : MonoBehaviour
{
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�

    public GameObject str_Prefab;
    public Transform pos;

    private bool attack;
    private float my_at_sp;

    Animator animator;

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
        my_at_sp += Time.deltaTime;     // ���ݼӵ� ������ ���

        // �ֺ��� �ִ� ��� ability_enemy ������Ʈ�� �迭�� ������
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
                    Debug.Log("��Ÿ� ����");
                    break; // �̹� �ϳ��� ���ֿ� ���� ������ �����Ǿ����Ƿ� ������ �����մϴ�.
                }
                else
                {
                    attack = false;
                    animator.SetBool("Attack", false);
                }
            }
        }
        //�̰Ŷ����� ��ũ��Ʈ�� �ϳ� �� �������ϳ�...
        //�Ѿ� ��ġ�� Y�� ����Ұ�
        if (attack && my_at_sp >= AT_sp)
        {
            Vector3 spawnPosition1 = new Vector3(pos.position.x, 1f, pos.position.z);
            Vector3 spawnPosition2 = new Vector3(pos.position.x, -0.8f, pos.position.z);
            Vector3 spawnPosition3 = new Vector3(pos.position.x, -2.6f, pos.position.z);
            Instantiate(str_Prefab, spawnPosition1, transform.rotation);
            Instantiate(str_Prefab, spawnPosition2, transform.rotation);
            Instantiate(str_Prefab, spawnPosition3, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

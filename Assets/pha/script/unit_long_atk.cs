using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_long_atk : MonoBehaviour
{
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�

    public GameObject str_Prefab;
    public Transform pos;

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

        // �ֺ��� �ִ� ��� ability_enemy ������Ʈ�� �迭�� ������
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
                    break; // �̹� �ϳ��� ���ֿ� ���� ������ �����Ǿ����Ƿ� ������ �����մϴ�.
                }
                else
                {
                    attack = false;
                }
            }
        }

        if (attack && my_at_sp >= AT_sp)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
        {
            Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

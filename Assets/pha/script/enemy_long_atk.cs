using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_long_atk : MonoBehaviour
{
    public float AT_sp_e;      // ���ݼӵ�
    public float range_e;      // ���� �Ÿ�

    private bool attack;
    private float my_at_sp;

    public GameObject str_Prefab;
    public Transform pos;

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

        // �ֺ��� �ִ� ��� ability_float_close ������Ʈ�� �迭�� ������
        ability[] floatCloseEnemies = GameObject.FindObjectsOfType<ability>();

        // ��� ���� ���� �ݺ�
        foreach (ability floatCloseEnemy in floatCloseEnemies)
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
                    break; // �̹� �ϳ��� ���ֿ� ���� ������ �����Ǿ����Ƿ� ������ �����մϴ�.
                }
                else
                {
                    attack = false;
                }
            }
        }

        if (attack && my_at_sp >= AT_sp_e)    //��Ÿ� �ȿ� ���� �ְ� ���ݼӵ��� �����ϸ� ����
        {
            Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

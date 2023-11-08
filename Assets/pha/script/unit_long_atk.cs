using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_long_atk : MonoBehaviour
{
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�

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
            GameObject str_shot = Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

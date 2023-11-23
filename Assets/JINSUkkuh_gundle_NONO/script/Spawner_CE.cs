using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_CE : MonoBehaviour
{
    //inspector â���� ����, ����Ȯ��, ������, ������ Ȯ���� ��������

    [SerializeField]
    GameObject[] cook_unit;//�丮 ���� ���

    [SerializeField]
    float[] cook_percentage;//�丮 ���ֺ� ��ȯ Ȯ��


    [SerializeField]
    Transform spawnPoint;//������

    [SerializeField]
    float[] cooltime;//���� �lŸ��

    [SerializeField]
    float first_spawn;//ù �丮���� ��ȯ�ð�

    private float cool;
    private int gh = 0;

    //���� ����� ���� ü�� ������ ������ѳ��� �ʾ� ������ ���� �ʵ��� ���Ǹ� �س���
    //���� ���� ���α׷����� �ϴ� ������ ��ũ��Ʈ���� ü�º����� ������ ����
    //e_hp = ob.GetComponent <???> ().e_hp;
    private float e_hp = 7000;
    //���� ���� �� ���� �Ʊ��� �󸶳� �����ϴ��� (��ȯ�ɋ� ������ 1�� ���ϰ� ���������� 1�� ���ҽ�ų ����)
    private int our_unit1 = 0;
    private int our_unit2 = 0;
    private int our_unit3 = 0;

    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cool = first_spawn;
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        //�� ������ ü���� ���� ������ ��� ����
        if (e_hp < 3500)
            gh = 2;

        if (timeAfterSpawn >= cool)
        {
            //�� ���� �� ��ġ ���ϱ�
            GetRow();

            Instantiate(cook_unit[GetRandom(cook_percentage, cook_percentage.Length, cook_unit.Length)], spawnPoint);

            cool = Random.Range(cooltime[0] - gh, cooltime[1] - gh);
            timeAfterSpawn = 0f;
        }
    }

    //������ ���ϴ� �Լ�
    private void GetRow()
    {
        int a = 0, b = 0, c = 0;
        int line;
        float[] line_percentages = { 30, 30, 30 };

        //���� �����ϴ� �Ʊ� ���ּ��� ���� �̻��� �� �ش� ���ο� ������ Ȯ�� ����
        if (our_unit1 > 5)
            a = 40;
        if (our_unit2 > 5)
            b = 40;
        if (our_unit3 > 5)
            c = 40;
        line_percentages[0] = 30 + a;
        line_percentages[1] = 30 + b;
        line_percentages[2] = 30 + c;

        Transform objectTransform = gameObject.GetComponent<Transform>();
        line = GetRandom(line_percentages, 3, 3);

        //�� ���� ��ǥ�� �Է��� ����
        if (line == 0)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
        if (line == 1)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
        if (line == 2)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
    }


    //Ȯ�� ���� �Լ�

    private int GetRandom(float[] percentages, int p_count, int o_count)
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < p_count; i++)
        {
            total += percentages[i];
        }

        for (int i = 0; i < o_count; i++)
        {
            if (percentages[i] / total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += percentages[i] / total;
            }
        }
        return 0;
    }
}
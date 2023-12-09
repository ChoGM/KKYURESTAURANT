using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner_E : MonoBehaviour
{
    //inspector â���� ����, ����Ȯ��, ������, ������ Ȯ���� ��������
    [Tooltip("������ �� Ȯ�� *������ ������ ��Ŀ, ����� ��Ŀ, �ٰŸ� ����, ���Ÿ� ����, ������ ��������")]
    [SerializeField]
    float[] p_percentages = new float[5];//������ �� Ȯ�� *������ ������ ��Ŀ, ����� ��Ŀ, �ٰŸ� ����, ���Ÿ� ����, ������ ��������

    int[] unitPosition = new int[5];//���� ������

    [SerializeField]
    GameObject[] rush_tnak;//������ ��Ŀ �������� ���� ���
    [SerializeField]
    float[] rush_tnak_percentage;//������ ��Ŀ �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] guard_tnak;//����� ��Ŀ �������� ���� ���
    [SerializeField]
    float[] guard_tnak_percentage;//����� ��Ŀ �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] close_deal;//�ٰŸ� ���� �������� ���� ���
    [SerializeField]
    float[] close_deal_percentage;//�ٰŸ� ���� �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] long_deal;//���Ÿ� ���� �������� ���� ���
    [SerializeField]
    float[] long_deal_percentage;//���Ÿ� ���� �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] support;//������ �������� ���� ���
    [SerializeField]
    float[] support_percentage;//������ �������� ���ֺ� ��ȯ Ȯ��

    [Tooltip("�ּҰ�, �ִ밪")]
    [SerializeField]
    float[] cooltime = new float[2];//���� �lŸ��

    //[SerializeField]
    //Transform spawnPoint;//������

    public Transform pos;
    private float cool;
    private int gh = 0;
    private int unit_position;

    //���� ����� ���� ü�� ������ ������ѳ��� �ʾ� ������ ���� �ʵ��� ���Ǹ� �س���
    //���� ���� ���α׷����� �ϴ� ������ ��ũ��Ʈ���� ü�º����� ������ ����
    //e_hp = ob.GetComponent <???> ().e_hp;
    private float e_hp = 7000;
    //���� ���� �� ���� �Ʊ��� �󸶳� �����ϴ��� (��ȯ�ɋ� ������ 1�� ���ϰ� ���������� 1�� ���ҽ�ų ����)
    private int our_unit1 = 0;
    private int our_unit2 = 0;
    private int our_unit3 = 0;

    private float[] original_p = new float[5];

    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        change(original_p, p_percentages);

        cool = 3;
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
            Transform objectTransform = gameObject.GetComponent<Transform>();

            //�������� = ������ ���� ex)������ ��Ŀ, ���Ÿ� ���� ��� -> �ش� �������� ���� ���� -> ��ȯ �� �ش� ������ Ȯ�� ����

            //1. Ȯ���� ���� ��ȯ�Ǵ� ���� ������ ����
            //0 = ������ ��Ŀ, 1 = ����� ��Ŀ, 2 = �ٰŸ� ����, 3 = ���Ÿ� ����, 4 = ������ 
            unit_position = GetRandom(p_percentages, 5, 5);
            if (unit_position == 0)
            {
                //2. ������ ���� �������� ������ Ȯ���� ���� ��ȯ
                Instantiate(rush_tnak[GetRandom(rush_tnak_percentage, rush_tnak_percentage.Length, rush_tnak.Length)], pos.position, transform.rotation);

                change(p_percentages, original_p);

                //3. ������ ��ȯ�� ���� ���� �������� �������� ������ ��ȯ�Ǵ� ���� ���� �ϱ����� ���� �����Ǻ� Ȯ���� ����
                //Percents_Adj(unit_position, rt, gt, cd, ld, sp);
            }

            else if (unit_position == 1)
            {
                Instantiate(guard_tnak[GetRandom(guard_tnak_percentage, guard_tnak_percentage.Length, guard_tnak.Length)], pos.position, transform.rotation);
                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            else if (unit_position == 2)
            {
                Instantiate(close_deal[GetRandom(close_deal_percentage, close_deal_percentage.Length, close_deal.Length)], pos.position, transform.rotation);
                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            else if (unit_position == 3)
            {
                Instantiate(long_deal[GetRandom(long_deal_percentage, long_deal_percentage.Length, long_deal.Length)], pos.position, transform.rotation);
                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            else
            {
                Instantiate(support[GetRandom(support_percentage, support_percentage.Length, support.Length)], pos.position, transform.rotation);
                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            //��Ÿ�� ���ϱ�
            //�� ������ ü���� ���� ������ ��� ��Ÿ���� ���̱�(���� ��ȯ�ǵ��� -> ���̵� ���)
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
            objectTransform.position = new Vector2(5.0f, 1.0f);
        }
        if (line == 1)
        {
            objectTransform.position = new Vector2(5.0f, 0.0f);
        }
        if (line == 2)
        {
            objectTransform.position = new Vector2(5.0f, -1.0f);
        }
    }

    //���� �����Ǻ� Ȯ���� �����ϴ� �Լ�
    //�̰Ͱ� ����� �������� �� ���� ü���� ���� ������ ��� �� �ڽ�Ʈ�� ���� ������ ���� �󵵰� ������ Ȯ�� ���� ���� (������)

    private void change(float[] original_p, float[] p_percentages)
    {
        for(int i = 0; i < 5;  i++)
        {
            original_p[i] = p_percentages[i];
        }
    }

    private void Percents_Adj(int i)
    {
        float a = 1, b = 1, c = 1, d = 1, e = 1;
        if (i == 0)
            a = 0.6f;
        else if (i == 1)
            b = 0.6f;
        else if (i == 2)
            c = 0.6f;
        else if (i == 3)
            d = 0.6f;
        else
            e = 0.6f;
        p_percentages[0] = p_percentages[0] * a;//������ ��Ŀ
        p_percentages[1] = p_percentages[1] * b;//����� ��Ŀ
        p_percentages[2] = p_percentages[2] * c;//�ٰŸ� ����
        p_percentages[3] = p_percentages[3] * d;//���Ÿ� ����
        p_percentages[4] = p_percentages[4] * e;//������
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
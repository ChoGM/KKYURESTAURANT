using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_E : MonoBehaviour
{
    //inspector â���� ����, ����Ȯ��, ������, ������ Ȯ���� ��������
    [SerializeField]
    float[] p_percentages;//������ �� Ȯ��
    [SerializeField]
    float[] unitPosition;//���� ������

    [SerializeField]
    float[] rush_tnak_percentage;//������ ��Ŀ �������� ���ֺ� ��ȯ Ȯ��
    [SerializeField]
    GameObject[] rush_tnak;//������ ��Ŀ �������� ���� ���

    [SerializeField]
    float[] guard_tnak_percentage;//����� ��Ŀ �������� ���ֺ� ��ȯ Ȯ��
    [SerializeField]
    GameObject[] guard_tnak;//����� ��Ŀ �������� ���� ���

    [SerializeField]
    float[] close_deal_percentage;//���� ���� �������� ���ֺ� ��ȯ Ȯ��
    [SerializeField]
    GameObject[] close_deal;//���� ���� �������� ���� ���

    [SerializeField]
    float[] long_deal_percentage;//���Ÿ� ���� �������� ���ֺ� ��ȯ Ȯ��
    [SerializeField]
    GameObject[] long_deal;//���Ÿ� ���� �������� ���� ���

    [SerializeField]
    float[] support_percentage;//������ �������� ���ֺ� ��ȯ Ȯ��
    [SerializeField]
    GameObject[] support;//������ �������� ���� ���

    [SerializeField]
    Transform spawnPoint;//������

    private float cool;
    private int gh;

    //���� ����� ���� ü�� ������ ������ѳ��� �ʾ� ������ ���� �ʵ��� ���Ǹ� �س���
    //���� ���� ���α׷����� �ϴ� ������ ��ũ��Ʈ���� ü�º����� ������ ����
    //e_hp = ob.GetComponent <???> ().e_hp;
    private float e_hp = 7000;

    private float timeAfterSpawn;
    private float line;

    // Start is called before the first frame update
    void Start()
    {
        cool = Random.Range(3, 6);
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
            
            //�������� = ������ ���� ex)������ ��Ŀ, ���Ÿ� ���� ��� -> �ش� �������� ���� ���� -> ��ȯ �� �ش� ������ Ȯ�� ����

            //1. Ȯ���� ���� ��ȯ�Ǵ� ������ ������ ����
            //0 = ������ ��Ŀ, 1 = ����� ��Ŀ, 2 = �ٰŸ� ����, 3 = ���Ÿ� ����, 4 = ������ 
            if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 0)
            {
                //2. ������ �������� ������ Ȯ���� ���� ��ȯ
                Instantiate(rush_tnak[GetRandom(rush_tnak_percentage, rush_tnak_percentage.Length, rush_tnak.Length)], spawnPoint);

                //3. ������ ��ȯ�� ���� �������� �������� ������ ��ȯ�Ǵ� ���� ���� �ϱ����� �����Ǻ� Ȯ���� ����
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 1)
            {
                Instantiate(guard_tnak[GetRandom(guard_tnak_percentage, guard_tnak_percentage.Length, guard_tnak.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 2)
            {
                Instantiate(rush_tnak[GetRandom(close_deal_percentage, close_deal_percentage.Length, close_deal.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 3)
            {
                Instantiate(rush_tnak[GetRandom(long_deal_percentage, long_deal_percentage.Length, long_deal.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else
            {
                Instantiate(rush_tnak[GetRandom(support_percentage, support_percentage.Length, support.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }
            
            //��Ÿ�� ���ϱ�
            //�� ������ ü���� ���� ������ ��� ��Ÿ���� ���̱�(���� ��ȯ�ǵ��� -> ���̵� ���)
            cool = Random.Range(4-gh, 6-gh);
            timeAfterSpawn = 0f;
        }
    }

    //������ ���ϴ� �Լ�
    private void GetRow()
    {
        line = Random.Range(1, 4);

        Transform objectTransform = gameObject.GetComponent<Transform>();

        //�� ���� ��ǥ�� �Է��� ����
        if (line == 1)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
        if (line == 2)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
        if (line == 3)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
    }

    //�����Ǻ� Ȯ���� �����ϴ� �Լ�
    //�̰Ͱ� ����� �������� �� ���� ü���� ���� ������ ��� �� �ڽ�Ʈ�� ���� ������ ���� �󵵰� ������ Ȯ�� ���� ���� (������)
    private void Percents_Adj(int i)
    {
        int a = 0, b = 0, c = 0, d = 0, e = 0;
        if (i == 0)
            a = -10;
        else if (i == 1)
            b = -10;
        else if (i == 2)
            c = -10;
        else if (i == 3)
            d = -10;
        else
            e = -10;
        p_percentages[0] = 20+a;//������ ��Ŀ
        p_percentages[1] = 20+b;//����� ��Ŀ
        p_percentages[2] = 30+c;//�ٰŸ� ����
        p_percentages[3] = 30+d;//���Ÿ� ����
        p_percentages[4] = 15+e;//������
    }

    //Ȯ�� ���� �Լ�

    private int GetRandom(float[] percentages, int p_count, int o_count)
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i <  p_count; i++)
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
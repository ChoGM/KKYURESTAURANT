using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner_E : MonoBehaviour
{
    public Transform pos;
    public GameObject unit1;
    private float cool;
    private float position;
    private float line;
    private float unit;
    private float timeAfterSpawn;
    public GameObject bob;
    public GameObject pigmeat;
    public GameObject gim;
    public GameObject sweetpotato;
    public GameObject sausage;
    public GameObject carrot;
    public GameObject ricecake;
    public GameObject noodle;
    public GameObject frymix;
    public GameObject sauce;
    public GameObject egg;
    public GameObject fishcake;


    //���� ����� ���� ü�� ������ ������ѳ��� �ʾ� ������ ���� �ʵ��� ���Ǹ� �س���
    private float e_hp = 7000;

    void Start()
    {
        cool = Random.Range(3, 6);
        timeAfterSpawn = 0f;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        //���� ���� ���α׷����� �ϴ� ������ ��ũ��Ʈ���� ü�º����� ������ ����
        //e_hp = ob.GetComponent <???> ().e_hp;

        if (timeAfterSpawn >= cool)
        {
            //�� ���� �� ��ġ ���ϱ�
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

            //��� ������ ü�� ������ ���� Ȯ���� �����Ұ���
            if (e_hp >= 3500)
            {
                //position = ���� �������� *���� ���ߵ��������� ������ ����
                //����, ��� ��Ŀ = ���� 20%
                //�ٰŸ�, ���Ÿ� ���� = ���� 25%
                //���� + ���� = 10%

                position = Random.Range(1, 101);

                if (position < 21) //������ ��Ŀ
                {
                    //unit = Ư�� ���� ���� *Ȯ���� ������������ ���� ���� ������ ����
                    unit = Random.Range(1, 101);
                    if (position < 51)
                        Instantiate(bob, pos.position, transform.rotation);
                    else
                        Instantiate(pigmeat, pos.position, transform.rotation);
                }
                if (position > 20 && position < 41) //����� ��Ŀ
                {
                    if (position < 51)
                        Instantiate(gim, pos.position, transform.rotation);
                    else
                        Instantiate(sweetpotato, pos.position, transform.rotation);
                }
                if (position > 40 && position < 66) //�ٰŸ� ����
                {
                    if (position < 31)
                        Instantiate(sausage, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(carrot, pos.position, transform.rotation);
                    else
                        Instantiate(ricecake, pos.position, transform.rotation);
                }
                if (position > 65 && position < 91) //������ ��Ŀ
                {
                    if (position < 51)
                        Instantiate(frymix, pos.position, transform.rotation);
                    else
                        Instantiate(noodle, pos.position, transform.rotation);
                }
                if (position > 90 && position < 101) //���� + ����
                {
                    if (position < 31)
                        Instantiate(sauce, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(egg, pos.position, transform.rotation);
                    else
                        Instantiate(fishcake, pos.position, transform.rotation);
                }
            }

            // ��� ������ ü���� ���� ���Ϸ� ���������� Ȯ�� ����
            else
            {
                position = Random.Range(1, 101);

                if (position < 21) //������ ��Ŀ
                {
                    unit = Random.Range(1, 101);
                    if (position < 51)
                        Instantiate(bob, pos.position, transform.rotation);
                    else
                        Instantiate(pigmeat, pos.position, transform.rotation);
                }
                if (position > 20 && position < 41) //����� ��Ŀ
                {
                    if (position < 51)
                        Instantiate(gim, pos.position, transform.rotation);
                    else
                        Instantiate(sweetpotato, pos.position, transform.rotation);
                }
                if (position > 40 && position < 66) //�ٰŸ� ����
                {
                    if (position < 31)
                        Instantiate(sausage, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(carrot, pos.position, transform.rotation);
                    else
                        Instantiate(ricecake, pos.position, transform.rotation);
                }
                if (position > 65 && position < 91) //������ ��Ŀ
                {
                    if (position < 51)
                        Instantiate(frymix, pos.position, transform.rotation);
                    else
                        Instantiate(noodle, pos.position, transform.rotation);
                }
                if (position > 90 && position < 101) //���� + ����
                {
                    if (position < 31)
                        Instantiate(sauce, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(egg, pos.position, transform.rotation);
                    else
                        Instantiate(fishcake, pos.position, transform.rotation);
                }
            }
            //���� ��Ÿ�� ���ϱ�
            cool = Random.Range(3, 6);
            timeAfterSpawn = 0f;
        }
    }
}

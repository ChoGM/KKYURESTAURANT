using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability_enemy : MonoBehaviour
{
    public float HP_e;
    public float ATK_e;
    public float DEF_e;

    GameObject flying_F;
    GameObject noodle;
    GameObject sotsot;
    GameObject rtbk;

    GameObject obj;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        flying_F = GameObject.Find("Frying_flour");
        noodle = GameObject.Find("Noodle");
        sotsot = GameObject.Find("Sotteok_Sotteok");
        rtbk = GameObject.Find("Laboki");
        // ���Ÿ� ���ֵ��� �ҷ���

        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP_e <= 0)   //ü���� 0�� �Ǹ� �����
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1(Clone)")   //Ƣ�谡��
        //�ε��� ��ü�� �±׸� ���ؼ� �Ѿ����� �Ǵ��մϴ�.
        {
            // ü�� - (���� ���ݷ� - �ڽ��� ����)
            HP_e -= (flying_F.GetComponent<ability>().ATK - (flying_F.GetComponent<ability>().ATK * DEF_e));

            sprite.color = Color.red;   //���ݴ��ϸ� ���� ����
            Invoke("color", 0.2f);

            //�Ѿ��� �ı��մϴ�.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2(Clone)")   //��
        {
            HP_e -= (noodle.GetComponent<ability>().ATK - (noodle.GetComponent<ability>().ATK  * DEF_e));
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3(Clone)")   //�Ҷ��Ҷ�
        {
            HP_e -= (sotsot.GetComponent<ability>().ATK - (sotsot.GetComponent<ability>().ATK * DEF_e));
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4(Clone)")   //����
        {
            HP_e -= (rtbk.GetComponent<ability>().ATK - (rtbk.GetComponent<ability>().ATK * DEF_e));
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(int x)
    {
        switch (x)
        {
            case 1:     //��

                obj = GameObject.Find("Bob");
                break;

            case 2:     //�������

                obj = GameObject.Find("Pork");
                break;

            case 3:     //��
                break;
            case 4:     //����
                break;
            case 5:     //�ҽ���
                break;
            case 6:     //���
                break;
            case 7:     //��
                break;
            case 8:     //����ҽ�
                break;
            case 9:     //���
                break;
            case 10:    //����
                break;
            case 11:    //���
                break;
            case 12:    //���
                break;
            case 13:    //����Ƣ��
                break;
            case 14:    //�������
                break;
            case 15:    //������
                break;
            case 16:    //���Ƕ��̽�
                break;
            case 17:    //���
                break;
            default:
                // �⺻������ �Ҵ��� ������Ʈ�� ���� ��� null�� �����ϰų�, �ٸ� ó���� ������ �� �ֽ��ϴ�.
                obj = null;
                break;
        }

        if (obj != null)
        {
            HP_e -= (obj.GetComponent<ability>().ATK - (obj.GetComponent<ability>().ATK * DEF_e));
            sprite.color = Color.red;
            Invoke("color", 0.2f);
        }
    }

    public void color()
    {
        sprite.color = Color.cyan;
    }
}

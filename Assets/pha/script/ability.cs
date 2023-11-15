using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float HP;         // ü��
    public float ATK;        // ���ݷ�
    public float DEF;        // ����

    GameObject flying_F_e;
    GameObject noodle_e;
    GameObject sotsot_e;
    GameObject rtbk_e;

    GameObject obj;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        flying_F_e = GameObject.Find("Frying_flour_enemy");
        noodle_e = GameObject.Find("Noodle_enemy");
        sotsot_e = GameObject.Find("Sotteok_Sotteok_enemy");
        rtbk_e = GameObject.Find("Laboki_enemy");

        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)   //ü���� 0�� �Ǹ� �����
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1_e(Clone)")   //Ƣ�谡��
        //�ε��� ��ü�� �±׸� ���ؼ� �Ѿ����� �Ǵ��մϴ�.
        {
            // ü�� - (���� ���ݷ� - �ڽ��� ����)
            HP -= (flying_F_e.GetComponent<ability_enemy>().ATK_e - DEF);
            sprite.color = Color.red;   //���ݴ��ϸ� ���� ����
            Invoke("color", 0.2f);

            //�Ѿ��� �ı��մϴ�.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2_e(Clone)")   //��
        {
            HP -= (noodle_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3_e(Clone)")   //�Ҷ��Ҷ�
        {
            HP -= (sotsot_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4_e(Clone)")   //����
        {
            HP -= (rtbk_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(int x)
    {
        switch (x)
        {
            case 1:     //��

                obj = GameObject.Find("Bob_enemy");
                break;

            case 2:     //�������

                obj = GameObject.Find("Pork_enemy");
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

        }

        HP -= (obj.GetComponent<ability_enemy>().ATK_e - (obj.GetComponent<ability_enemy>().ATK_e * DEF));
        sprite.color = Color.red;   //���ݴ��ϸ� ���� ����
        Invoke("color", 0.2f);
    }

    public void color()
    {
        sprite.color = Color.white;
    }
}

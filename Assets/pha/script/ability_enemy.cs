using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability_enemy : MonoBehaviour
{
    public float HP_e;
    public float ATK_e;
    public float DEF_e;
    public float AT_sp_e;
    public float range_e;

    GameObject flying_F;
    GameObject noodle;
    GameObject sotsot;
    GameObject rtbk;
    // Start is called before the first frame update
    void Start()
    {
        flying_F = GameObject.Find("Frying_flour");
        noodle = GameObject.Find("Noodle");
        sotsot = GameObject.Find("Sotteok_Sotteok");
        rtbk = GameObject.Find("Laboki");
        // ���Ÿ� ���ֵ��� �ҷ���
        
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
            HP_e -= (flying_F.GetComponent<ability>().ATK - DEF_e);
            
            //�Ѿ��� �ı��մϴ�.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2")   //��
        {
            HP_e -= (noodle.GetComponent<ability>().ATK - DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3")   //�Ҷ��Ҷ�
        {
            HP_e -= (sotsot.GetComponent<ability>().ATK - DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4")   //����
        {
            HP_e -= (rtbk.GetComponent<ability>().ATK - DEF_e);
            Destroy(other.gameObject);
        }
    }
}

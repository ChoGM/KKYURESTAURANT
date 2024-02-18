using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_enemy : MonoBehaviour
{
    public float HP_e;
    public float DEF_e;

    public float Hit_e;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    { 
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP_e <= 0)   //ü���� 0�� �Ǹ� �����
        {
            GetComponent<Death>().enabled = true;
        }
    }

    public void long_hit(float x)
    {
        Hit_e = x;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1(Clone)")   //Ƣ�谡��
        //�ε��� ��ü�� �±׸� ���ؼ� �Ѿ����� �Ǵ��մϴ�.
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit_e = enemyScript.ATK_L;
            }

            // ü�� - (���� ���ݷ� - �ڽ��� ����)
            HP_e -= Hit_e - (Hit_e * DEF_e);

            sprite.color = Color.red;   //���ݴ��ϸ� ���� ����
            Invoke("color", 0.2f);

            //�Ѿ��� �ı��մϴ�.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2(Clone)")   //��
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit_e = enemyScript.ATK_L;
            }

            HP_e -= Hit_e - (Hit_e * DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3(Clone)")   //�Ҷ��Ҷ�
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit_e = enemyScript.ATK_L;
            }

            HP_e -= Hit_e - (Hit_e * DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4(Clone)")   //����
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit_e = enemyScript.ATK_L;
            }

            HP_e -= Hit_e - (Hit_e * DEF_e);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(float hit)
    {

        Debug.Log("���� ����");
        HP_e -= hit - (hit * DEF_e);
        sprite.color = Color.red;
        Invoke("color", 0.2f);
        
    }

    public void color()
    {
        sprite.color = Color.cyan;
    }
}

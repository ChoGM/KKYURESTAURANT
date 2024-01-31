using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float HP;         // ü��
    public float DEF;        // ����

    public float Hit;

    SpriteRenderer sprite;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)   //ü���� 0�� �Ǹ� �����
        {
            GetComponent<Death>().enabled = true;
        }
    }

    public void long_hit(float x)
    {
        Hit = x;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1_e(Clone)")   //Ƣ�谡��
        //�ε��� ��ü�� �±׸� ���ؼ� �Ѿ����� �Ǵ��մϴ�.
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit = enemyScript.ATK_L_e;
            }

            // ü�� - (���� ���ݷ� - �ڽ��� ����)
            HP -= Hit - (Hit * DEF);
            sprite.color = Color.red;   //���ݴ��ϸ� ���� ����
            Invoke("color", 0.2f);

            //�Ѿ��� �ı��մϴ�.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2_e(Clone)")   //��
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit = enemyScript.ATK_L_e;
            }

            HP -= Hit - (Hit * DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3_e(Clone)")   //�Ҷ��Ҷ�
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit = enemyScript.ATK_L_e;
            }

            HP -= Hit - (Hit * DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4_e(Clone)")   //����
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // ��ũ��Ʈ�� �����ϸ� ������ ���� ����
            if (enemyScript != null)
            {
                // ���⿡�� enemyScript�� ������ �����Ͽ� ���
                Hit = enemyScript.ATK_L_e;
            }

            HP -= Hit - (Hit * DEF);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(float hit)
    {
        HP -= hit - (hit * DEF);
        sprite.color = Color.red;   //���ݴ��ϸ� ���� ����
        Invoke("color", 0.2f);
   
    }

    public void color()
    {
        sprite.color = Color.white;
    }
}

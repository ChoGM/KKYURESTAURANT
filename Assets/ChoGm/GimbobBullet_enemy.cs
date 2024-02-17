using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimbobBullet_enemy : MonoBehaviour
{
    public float speed;
    public float damage;
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -speed * Time.deltaTime);
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ability ability = collision.GetComponent<Ability>();
        if (ability != null)
        {
            // HP_e ���� 10 ����
            ability.HP -= damage;
        }
    }

}
//����� �ִϸ��̼� �����ϱ�
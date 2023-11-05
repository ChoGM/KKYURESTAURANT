using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHp : MonoBehaviour
{
    private float maxHp = 10f;
    private float curHp = 1f;

    public float Enemyvalue;

    // Start is called before the first frame update
    void Start()
    {
        Enemyvalue = maxHp;

    }


    private void OnCollisionEnter2D(Collision2D collision) // ���̾�� �浹�� �ν��ҷ� ������ istrigger�� ���� �浹���� �ȵ�
    {
        Enemyvalue -= curHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (Enemyvalue == 0f)
        {
            Destroy(gameObject);
        }
    }
}

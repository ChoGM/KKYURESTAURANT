using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    private float maxHp = 10f;
    private float curHp = 1f;

    public float value;

    // Start is called before the first frame update
    void Start()
    {
        value = maxHp;

    }


    private void OnCollisionEnter2D(Collision2D collision) // ���̾�� �浹�� �ν��ҷ� ������ istrigger�� ���� �浹���� �ȵ�
    {
        value -= curHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value == 0f)
        {
            Destroy(gameObject);
        }
    }
}

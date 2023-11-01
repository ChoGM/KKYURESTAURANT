using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    private float speed;
    private bool closeEnemy;    
    private float rangeEnemy;   //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        rangeEnemy = 5.0f;      //������ ��Ÿ��� ���� ��ũ��Ʈ �޾ƿ���
        closeEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(closeEnemy == true)
            transform.Translate(speed * Time.deltaTime, 0, 0);

        if (closeEnemy == false)
            transform.Translate(0, 0, 0);
    }
}

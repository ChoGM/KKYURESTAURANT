using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dex_atk : MonoBehaviour
{
    public float shot_speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);    //�ð��� ������ �������
    }

    // Update is called once per frame
    void Update()
    {
        // �Ѿ� �߻�
        transform.Translate(transform.right * shot_speed * Time.deltaTime);
    }

}

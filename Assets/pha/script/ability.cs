using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float HP;         // ü��
    public float ATK;        // ���ݷ�
    public float DEF;        // ����
    public float AT_sp;      // ���ݼӵ�
    public float range;      // ���� �Ÿ�

    private float my_at_sp;
    
    public GameObject str_Prefab;
    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        my_at_sp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        my_at_sp += Time.deltaTime;

        if (my_at_sp == AT_sp)
        {
            GameObject str_shot = Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

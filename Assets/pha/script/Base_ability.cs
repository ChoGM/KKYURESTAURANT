using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_ability : MonoBehaviour
{
    public float Full_HP;         // ü��

    public float Hit;

    SpriteRenderer sprite;
    public Ability ability;

    public GameObject Background_battle_base;

    // Start is called before the first frame update
    void Start()
    {
        ability = GetComponent<Ability>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Background_battle_base = GameObject.Find("Background_battle_base");
    }

    // Update is called once per frame
    void Update()
    {
        Full_HP = ability.HP;
        if (Full_HP != 100)   //ü���� 0�� �ƴ� ���
        {
            Hit = 100 - Full_HP;
            BaseHp baseHpScript = Background_battle_base.GetComponent<BaseHp>();
            baseHpScript.curHealth = baseHpScript.curHealth - Hit;
        }
        ability.HP = 100;
    }

   

}

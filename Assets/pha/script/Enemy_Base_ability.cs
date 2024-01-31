using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base_ability : MonoBehaviour
{
    public float Full_HP;         // ü��

    public float Hit;

    SpriteRenderer sprite;
    public Ability_enemy ability_e;

    public GameObject Background_battle_base;

    // Start is called before the first frame update
    void Start()
    {
        ability_e = GetComponent<Ability_enemy>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Background_battle_base = GameObject.Find("Background_battle_enemy base");
    }

    // Update is called once per frame
    void Update()
    {
        Full_HP = ability_e.HP_e;
        if (Full_HP != 100)   //ü���� 0�� �ƴ� ���
        {
            Hit = 100 - Full_HP;
            Enemy_BaseHp baseHpScript = Background_battle_base.GetComponent<Enemy_BaseHp>();
            baseHpScript.curHealth = baseHpScript.curHealth - Hit;
        }
        ability_e.HP_e = 100;
    }



}

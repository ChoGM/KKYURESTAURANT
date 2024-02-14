using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BaseHp : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpSlider();
        EndFight();
    }

    private void UpdateHpSlider()
    {
    }

    private void EndFight()
    {
        if (curHealth <= 0)
        {
            //���� ��ũ��Ʈ�� ���� ������Ʈ�� ����
            Ability[] objectsWithAbilityScript = FindObjectsOfType<Ability>();
            foreach (Ability obj in objectsWithAbilityScript)
            {
                Destroy(obj.gameObject);
            }
            Ability_enemy[] objectsWithAbilityScript1 = FindObjectsOfType<Ability_enemy>();
            foreach (Ability_enemy obj in objectsWithAbilityScript1)
            {
                Destroy(obj.gameObject);
            }
            LineSelection[] objectsWithLineScript = FindObjectsOfType<LineSelection>();
            foreach (LineSelection obj in objectsWithLineScript)
            {
                Destroy(obj.gameObject);
            }

            //�̸��� ���� ���� ������Ʈ�� ã�Ƽ� ����
            GameObject objectWithNameG = GameObject.Find("GameManager");
            if (objectWithNameG != null)
            {
                Destroy(objectWithNameG);
            }
            GameObject objectWithNameS = GameObject.Find("Spawner");
            if (objectWithNameS != null)
            {
                Destroy(objectWithNameS);
            }
            GameObject objectWithNameC = GameObject.Find("UnitCanvas");
            if (objectWithNameC != null)
            {
                Destroy(objectWithNameC);
            }
            GameObject objectWithNameCC = GameObject.Find("CoinCanvas");
            if (objectWithNameCC != null)
            {
                Destroy(objectWithNameCC);
            }
            Camera MainCamera = Camera.main;
            if (MainCamera != null)
            {
                TestBack Script = MainCamera.GetComponent<TestBack>();
                if (Script != null)
                {
                    Destroy(Script);
                }
            }

            canvas.SetActive(true);

            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                // AudioSource ã��
                AudioSource audioSource = mainCamera.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // AudioSource ����
                    Destroy(audioSource);
                }
            }
        }
    }
}


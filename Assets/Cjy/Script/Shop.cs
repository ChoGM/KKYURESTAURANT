using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�߰�
using UnityEngine.SceneManagement; //�߰�

public class Shop : MonoBehaviour
{
    public float CoinInt; // ������ ����Ǵ� ����
    public Text CoinText; //������ ǥ���� ������Ʈ
    public float Timer; //Ÿ�̸�
    private bool TimeSet; // Ÿ�̸� �۵�����
    public float UnitCoin; //���ֺ� ���� 

    void Start()
    {
        TimeSet = true;
        UnitCoin = 0;
    }

    void Update()
    {
        CoinText.text = (int)CoinInt + " /2000";

        if (TimeSet == true) // TimeSet�� True��
        {
            Timer += Time.deltaTime; // Ÿ�̸Ӱ� �۵�
            if (Timer > 1.0f) // 1�ʰ� ������
            {
                Timer = 0;
                CoinInt += 100f;

                if (CoinInt >= 2000f)
                {
                    TimeSet = false;
                }
            }
        }
    }


    public void lostMoney() // ���� ����
    {
        if (CoinInt >= UnitCoin) // CoinInt�� �������� �̻��̶��
        {
            Debug.Log("����" + UnitCoin);
            CoinInt -= UnitCoin; // CoinInt�� ���� ���θ�ŭ ��
            TimeSet = true;

        }
    }

}

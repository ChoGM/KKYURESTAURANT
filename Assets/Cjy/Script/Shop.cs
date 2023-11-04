using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�߰�
using UnityEngine.SceneManagement; //�߰�
using UnityEditor.VersionControl;

public class Shop : MonoBehaviour
{
    public float CoinInt; // ������ ����Ǵ� ����
    public Text CoinText; //������ ǥ���� ������Ʈ
    public float Timer; //Ÿ�̸�
    private bool TimeSet; // Ÿ�̸� �۵�����

    void Start()
    {
        TimeSet = true;
    }

    void Update()
    {
        CoinText.text = (int)CoinInt + " /2000";

        if (TimeSet == true) // TimeSet�� True��
        {
            Timer += Time.deltaTime; // Ÿ�̸Ӱ� �۵��մϴ�.
            if (Timer > 1.0f) // 1�ʰ� ������
            {
                Timer = 0;
                CoinInt += 100f;
                
                if (CoinInt == 2000f)
                {
                    TimeSet = false;
                }
            }
        }
    }


    public void lostMoney() // ���� ����
    {
        if (CoinInt >= 100f) // CoinInt�� 100�̻��̶��
        {
            Debug.Log("�ƹ��ų�");
            CoinInt -= 100f; // CoinInt�� 100 ��
        }
    }

}

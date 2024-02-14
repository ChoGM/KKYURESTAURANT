using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;

    private bool isButtonClick = true;

    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (isButtonClick)
        {
            
            image1.SetActive(false);
            image2.SetActive(true);


            // �̹��� ���¸� ����
            isButtonClick = !isButtonClick;

        }
    }
}

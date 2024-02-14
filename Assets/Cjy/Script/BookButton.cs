using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButton : MonoBehaviour
{
    public GameObject[] images;
    private int currentIndex = 0;

    void Start()
    {
        // ù ��° �̹����� Ȱ��ȭ
        ActivateImage(currentIndex);
    }

    public void OnNextButtonClick()
    {
        // ���� �̹����� �̵�
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
        }
        else
        {
            Debug.Log("������ �̹����Դϴ�.");
            return;
        }
        ActivateImage(currentIndex);
    }

    public void OnPreviousButtonClick()
    {
        // ���� �̹����� �̵�
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        else
        {
            Debug.Log("ù ��° �̹����Դϴ�.");
            return;
        }
        ActivateImage(currentIndex);
    }

    private void ActivateImage(int index)
    {
        // ���� �ε����� �̹����� Ȱ��ȭ
        for (int i = 0; i < images.Length; i++)
        {
            if (i == index)
            {
                images[i].SetActive(true);
            }
            else
            {
                images[i].SetActive(false);
            }
        }
    }
}

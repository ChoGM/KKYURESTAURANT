using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public GameObject menuPanel;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    public void Menu_button()
    {
        Time.timeScale = 0; //���� �Ͻ�����
        menuPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void Home_Scene()
    {
        SceneManager.LoadScene("Kjs");
    }
}

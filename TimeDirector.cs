using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeDirector : MonoBehaviour
{
    public PlayerMove player;
    GameObject timerText;
    public bool timeCon = true; // Ÿ�ӿ��� �ߺ� �������� bool��
    float time = 0.0f;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        string currentSceneName = SceneManager.GetActiveScene().name; // currentSceneName�� ���� �� �̸� �ޱ�

        //�� �̸��� ���� time ����
        if (currentSceneName == "Game111") 
        {
            this.time = 40.0f;
        }
        else if (currentSceneName == "Game111s")
        {
            this.time = 40.0f;
        }
        else if (currentSceneName == "Game222")
        {
            this.time = 35.0f;
        }
        else if (currentSceneName == "Game222s")
        {
            this.time = 45.0f;
        }
    }

    void Update()
    {
        // Ÿ�̸�
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");

        // Ÿ�ӿ���
        if (this.time <= 0 && timeCon == true)
        {
            TimeOver();
        }


    }

    private void TimeOver()
    {
        player.timeOver = true; //PlayerMove��ũ��Ʈ�� timeOver�� true�� ����
        timeCon = false; //Ÿ�ӿ����� �ߺ����� �ʰ� �ϱ�
    }
}

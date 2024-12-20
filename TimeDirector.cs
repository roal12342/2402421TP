using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeDirector : MonoBehaviour
{
    public PlayerMove player;
    GameObject timerText;
    public bool timeCon = true; // 타임오버 중복 막기위한 bool값
    float time = 0.0f;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        string currentSceneName = SceneManager.GetActiveScene().name; // currentSceneName에 현재 씬 이름 받기

        //씬 이름에 따른 time 설정
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
        // 타이머
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");

        // 타임오버
        if (this.time <= 0 && timeCon == true)
        {
            TimeOver();
        }


    }

    private void TimeOver()
    {
        player.timeOver = true; //PlayerMove스크립트의 timeOver을 true로 설정
        timeCon = false; //타임오버가 중복되지 않게 하기
    }
}

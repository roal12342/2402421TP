using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint11 : MonoBehaviour // 세이브포인트 오브젝트에 스크립트 넣음.
{
    private int stage = 0;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name; // currentSceneName에 현재 씬 이름 받기

        if (currentSceneName == "Game111")
        {
            this.stage = 1;
        }
        else if (currentSceneName == "Game111s")
        {
            this.stage = 1;
        }
        else if (currentSceneName == "Game222")
        {
            this.stage = 2;
        }
        else if (currentSceneName == "Game222s")
        {
            this.stage = 2;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // 충돌한 객체 태그 "Player"일 때만 실행
        {
            if (this.stage == 1)
            {
                SceneManager.LoadScene("Game111s"); // 세이브포인트 씬으로 이동
            }
            if (this.stage == 2)
            {
                SceneManager.LoadScene("Game222s"); // 세이브포인트 씬으로 이동
            }
            
        }
    }
}

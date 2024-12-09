using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint11 : MonoBehaviour // ���̺�����Ʈ ������Ʈ�� ��ũ��Ʈ ����.
{
    private int stage = 0;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name; // currentSceneName�� ���� �� �̸� �ޱ�

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
        if (collision.gameObject.tag == "Player") // �浹�� ��ü �±� "Player"�� ���� ����
        {
            if (this.stage == 1)
            {
                SceneManager.LoadScene("Game111s"); // ���̺�����Ʈ ������ �̵�
            }
            if (this.stage == 2)
            {
                SceneManager.LoadScene("Game222s"); // ���̺�����Ʈ ������ �̵�
            }
            
        }
    }
}

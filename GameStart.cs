using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    
    void OnMouseUp() //������Ʈ Ŭ���ϸ� "Game111"������; ���ӽ��� ��ư�� ��ũ��Ʈ ����
    {
        SceneManager.LoadScene("Game111");
    }
}

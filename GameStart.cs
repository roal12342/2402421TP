using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    
    void OnMouseUp() //오브젝트 클릭하면 "Game111"씬으로; 게임시작 버튼에 스크립트 넣음
    {
        SceneManager.LoadScene("Game111");
    }
}

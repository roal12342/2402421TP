using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public PlayerMove player; //PlayerMove 스크립트 가져오기
    private bool on = false;  // 오브젝트가 움직였는지 여부
    public int stage = 0;

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
        else if ( currentSceneName == "Game222s")
        {
            this.stage = 2;
        }
    }
    void FixedUpdate()
    {
        if (player != null && stage == 1)
        {
            Vector2 playerPosition = player.GetCurrentPosition(); //플레이어 좌표 가져오기

            if (playerPosition.x > transform.position.x -1.1 && playerPosition.y >3) //플레이어 x좌표가 (오브젝트x좌표-1.1) 초과하고, 플레이어 y좌표가 3 초과하면
            {
                // 뒤에 가려져서 안보이던 오브젝트 보이게
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;  
                if (!on)
                {
                    on = true;
                }
            }
            moveUp();
        }

        if (player != null && stage == 2)
        {
            Vector2 playerPosition = player.GetCurrentPosition(); //플레이어 좌표 가져오기

            if (playerPosition.x > transform.position.x - 1.1 && playerPosition.y > 6) //플레이어 x좌표가 (오브젝트x좌표-1.1) 초과하고, 플레이어 y좌표가 6 초과하면
            {
                // 뒤에 가려져서 안보이던 오브젝트 보이게
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                if (!on)
                {
                    on = true;
                }
            }
            moveUp();
        }
    }


    void moveUp()
    {
        if (on)
        {
            if (stage == 1)
                transform.Translate(0, 0.08f, 0);
            if (stage == 2)
                transform.Translate(0, 0.4f, 0);
        }
    }
}

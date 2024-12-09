using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveRight : MonoBehaviour
{
    public PlayerMove player;  //PlayerMove스크립트 가져오기
    public float moveDistance = 1.3f;  //이동거리 설정
    public float detectionDistance = 2f;  //플레이어와의 사이거리 설정
    private bool hasMoved = false;   //블럭 움직였는지 여부

    void Update()
    {
        if (player != null && !hasMoved)  //플레이어가 있고, 블럭 안움직였으면
        {
            Vector2 playerPosition = player.GetCurrentPosition();  //플레이어 좌표 가져오기

            if (playerPosition.x > transform.position.x - 2 && playerPosition.y < transform.position.y + 2)  //플레이어가 오브젝트보다 x-2, y+2 의 좌표에 오면 이동 
            {
                MoveRight();
            }
        }
    }

    void MoveRight() // 블럭 우측이동
    {
        transform.position += Vector3.right * moveDistance;
        hasMoved = true;
    }
}
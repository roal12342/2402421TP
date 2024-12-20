using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public PlayerMove player;  //PlayerMove 스크립트 가져오기

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();  //플레이어 좌표받아오기
            float newX = playerPosition.x; // 플레이어 x좌표를 newX에 할당
            transform.position = new Vector3(newX, 6, -10); // y,z좌표는 고정하고 x좌표만 플레이어 따라가기
        }
        
    }
}

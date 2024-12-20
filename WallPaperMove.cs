using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPaperMove : MonoBehaviour
{
    public PlayerMove player; //PlayerMove 참조

    void FixedUpdate()
    {
        // 플레이어 위치에 따라 배경화면x좌표만 같이 이동. 카메라 이동과 유사
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();
            float newX = playerPosition.x;
            transform.position = new Vector3(newX, 6, -5);
        }
        
    }
}

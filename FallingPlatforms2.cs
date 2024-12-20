using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingPlatforms2 : MonoBehaviour
{
    public PlayerMove player; // PlayerMove 스크립트 참조
    public Rigidbody2D rb; // 리지드바디2D 값 받을 변수
    public TilemapCollider2D Tc; // 타일맵콜라이더2D 값 받을 변수

    public void Start()
    {
        // 변수에 값 받기
        rb = GetComponent<Rigidbody2D>();
        Tc = GetComponent<TilemapCollider2D>();
        rb.isKinematic = true; // 중력효과 안받게
        Tc.isTrigger = false; // isTrigger X
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition(); //플레이어 좌표 받아오기

            if (playerPosition.x > 44 && playerPosition.x <47 && playerPosition.y>4 && playerPosition.y<5)
            {
                rb.isKinematic = false;
                Tc.isTrigger = true;
                gameObject.tag = "Enemy";
            }
        }
    }
}

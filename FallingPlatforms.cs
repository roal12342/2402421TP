using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    public Rigidbody2D rb; //리지드바디2D 

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //리지드바디2D의 값들을 rb에 받아오기
        rb.isKinematic = true; // 중력효과 안받게
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // 충돌한 객체 태그 "Player"일 때
        {
            rb.isKinematic = false; // 중력효과 받게
        }
    }
}

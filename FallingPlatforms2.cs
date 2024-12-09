using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingPlatforms2 : MonoBehaviour
{
    public PlayerMove player; // PlayerMove ��ũ��Ʈ ����
    public Rigidbody2D rb; // ������ٵ�2D �� ���� ����
    public TilemapCollider2D Tc; // Ÿ�ϸ��ݶ��̴�2D �� ���� ����

    public void Start()
    {
        // ������ �� �ޱ�
        rb = GetComponent<Rigidbody2D>();
        Tc = GetComponent<TilemapCollider2D>();
        rb.isKinematic = true; // �߷�ȿ�� �ȹް�
        Tc.isTrigger = false; // isTrigger X
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition(); //�÷��̾� ��ǥ �޾ƿ���

            if (playerPosition.x > 44 && playerPosition.x <47 && playerPosition.y>4 && playerPosition.y<5)
            {
                rb.isKinematic = false;
                Tc.isTrigger = true;
                gameObject.tag = "Enemy";
            }
        }
    }
}

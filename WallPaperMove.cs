using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPaperMove : MonoBehaviour
{
    public PlayerMove player; //PlayerMove ����

    void FixedUpdate()
    {
        // �÷��̾� ��ġ�� ���� ���ȭ��x��ǥ�� ���� �̵�. ī�޶� �̵��� ����
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();
            float newX = playerPosition.x;
            transform.position = new Vector3(newX, 6, -5);
        }
        
    }
}

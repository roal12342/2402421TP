using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveLeft : MonoBehaviour
{
    public PlayerMove player;  //PlayerMove��ũ��Ʈ ��������
    public float moveDistance = 1.3f;  //�̵��Ÿ� ����
    public float detectionDistance = 2f;  //�÷��̾���� ���̰Ÿ� ����
    private bool hasMoved = false;   //�� ���������� ����

    void Update()
    {
        if (player != null && !hasMoved)  //�÷��̾ �ְ�, �� �ȿ���������
        {
            Vector2 playerPosition = player.GetCurrentPosition();  //�÷��̾� ��ǥ ��������

            if (playerPosition.x> transform.position.x - 1 && playerPosition.y< transform.position.y + 2)  // �÷��̾ ������Ʈ���� x-1, y+2 �� ��ǥ�� ���� �̵� 
            {
                MoveLeft();
            }
        }
    }

    void MoveLeft() //�� �����̵�
    {
        transform.position += Vector3.left * moveDistance;
        hasMoved = true;
    }
}

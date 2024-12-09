using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public PlayerMove player;  //PlayerMove ��ũ��Ʈ ��������

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();  //�÷��̾� ��ǥ�޾ƿ���
            float newX = playerPosition.x; // �÷��̾� x��ǥ�� newX�� �Ҵ�
            transform.position = new Vector3(newX, 6, -10); // y,z��ǥ�� �����ϰ� x��ǥ�� �÷��̾� ���󰡱�
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    
    //�浹����
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // �浹�� ��ü �±װ� "Player"�� ��
        {
            Destroy(gameObject);
        }
        
    }

}

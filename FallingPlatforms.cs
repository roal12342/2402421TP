using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    public Rigidbody2D rb; //������ٵ�2D 

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //������ٵ�2D�� ������ rb�� �޾ƿ���
        rb.isKinematic = true; // �߷�ȿ�� �ȹް�
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // �浹�� ��ü �±� "Player"�� ��
        {
            rb.isKinematic = false; // �߷�ȿ�� �ް�
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Renderer hide;  // ������Ʈ�� Renderer

    void Start()
    {
        hide = GetComponent<Renderer>();

        // �ʱ� ���¿��� ������Ʈ�� ������ �ʰ� ����
        hide.enabled = false;
    }

    // �÷��̾�� �浹
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")  // �浹�� ��ü �̸��� "Player"�� ��
        {
            // ������Ʈ�� ���̰� ����
            hide.enabled = true;
        }
    }
}

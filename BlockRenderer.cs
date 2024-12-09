using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRenderer : MonoBehaviour
{
    private Renderer blockRenderer;  // �ڽ� ����� Renderer
    private Collider2D blockCollider;  // �ڽ� ����� Collider
    private PlayerMove player;  //PlayerMove ��ũ��Ʈ ��������

    void Start()
    {
        // �ڽ� ����� Renderer ������Ʈ�� ��������
        blockRenderer = GetComponent<Renderer>();

        // �ڽ� ����� Collider2D ������Ʈ�� ��������
        blockCollider = GetComponent<Collider2D>();

        // �ʱ� ���¿��� �ڽ� ����� ������ �ʰ� ����
        blockRenderer.enabled = false;

        // �ڽ� ����� �浹�� ��Ȱ��ȭ (isTrigger�� true�� ����)
        blockCollider.isTrigger = true;
    }

    // �÷��̾�� Trigger �浹���� �� ȣ��Ǵ� �޼���
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ��ü�� "Player" �±׸� ���� ��쿡�� ����
        if (collision.gameObject.tag == "Player")
        {
            // �÷��̾��� Rigidbody2D ��������
            Rigidbody2D playerRigidbody = collision.attachedRigidbody;

            // �÷��̾ �Ʒ����� ���� �̵��ϸ� �浹�� ���
            if (playerRigidbody != null && playerRigidbody.velocity.y > 0)
            {
                // �ڽ� ����� ���̰� ����
                blockRenderer.enabled = true;

                // ������ �浹 Ȱ��ȭ (isTrigger�� false�� ����)
                blockCollider.isTrigger = false;
            }
        }
    }
}
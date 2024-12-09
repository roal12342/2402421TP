using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBone : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("BoneDestroyed", 0) == 1)
        {
            Destroy(gameObject);  // ������Ʈ�� ������ �����Ǿ����� �ٽ� ����
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")  // �浹�� ��ü �̸��� "Player"�� ���� ����
        {
            Destroy(gameObject);

            PlayerPrefs.SetInt("BoneDestroyed", 1);
            PlayerPrefs.Save();  // ������ ����
        }
    }
}

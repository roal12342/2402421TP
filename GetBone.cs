using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBone : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("BoneDestroyed", 0) == 1)
        {
            Destroy(gameObject);  // 오브젝트가 이전에 삭제되었으면 다시 삭제
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")  // 충돌한 객체 이름이 "Player"일 때만 실행
        {
            Destroy(gameObject);

            PlayerPrefs.SetInt("BoneDestroyed", 1);
            PlayerPrefs.Save();  // 데이터 저장
        }
    }
}

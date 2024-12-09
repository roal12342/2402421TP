using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    
    public string sceneName;
    public TimeDirector Td;

    public Vector2 GetCurrentPosition()
    {
        return transform.position;
    }

    
    public float maxSpeed;  //플레이어 최대속도 제한
    public float jumpPower;  //플레이어 점프력
    public bool playerFall = false;  //플레이어 낙사
    public bool playerDie = false;  //플레이어 사망
    public bool timeOver = false;  //타임오버시 사망, TimeDirector 스크립트에서 조정

    public AudioSource audioSource;     
    public AudioClip jumpClip;        //점프 사운드  
    public AudioClip DieClip;          // 사망 사운드

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //점프
        if (Input.GetButtonUp("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            audioSource.PlayOneShot(jumpClip);
        }

        //정지
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //좌우변환
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (rigid.velocity.x == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
            anim.SetBool("isWalking", true);

        if(playerDie || timeOver)
        {
            rigid.velocity = Vector2.zero;
            StartCoroutine(PauseAndResume(2f));
        }
        if (timeOver) //타임오버시
        {
            timeOver = false; //타임오버 사운드 중복 안되게
            audioSource.PlayOneShot(DieClip); //사망 사운드
        }
    }
    IEnumerator PauseAndResume(float pauseDuration)
    {
        Time.timeScale = 0;  // 게임 일시 정지
        yield return new WaitForSecondsRealtime(pauseDuration);  // 실제 시간을 기준으로 기다림
        Time.timeScale = 1;  // 게임 재개
        loadScene();
    }

    
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // 수평 입력 값
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // 수평으로 이동

        if(rigid.velocity.x > maxSpeed) //최대속도 제한
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed*(-1))
        {
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }

        //착지
        if(rigid.velocity.y <= 0) // 플레이어가 하강하거나 정지한 상태
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform")); // 캐릭터 아래로 Raycast를 쏴서 "Platform" layer를 가진 오브젝트 감지

            if (rayHit.collider != null) // Raycast가 어떠한 플랫폼을 감지한경우
            {
                if (rayHit.distance < 0.6f) // 사이 거리 0.6 미만이면
                {
                    anim.SetBool("isJumping", false); //isJumping 상태 애니메이션을 false로 설정
                }
            }
        }

        // 낙사
        if (transform.position.y < -3 && !playerFall)
        {
            playerFall = true;
            audioSource.PlayOneShot(DieClip);
            Invoke("loadScene", 2f);
        }

        
        

    }

    
    //충돌판정
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Train") // 충돌한 객체 태그가 "Train"일 때
        {
            SceneManager.LoadScene("Game222"); // "Game222"씬으로 이동
        }
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("End");
        }
        if (collision.gameObject.tag == "Enemy") // 충돌한 객체 태그가 "Enemy"일 때
        {
            playerDie = true;
        }
        if (playerDie)
        {
            audioSource.PlayOneShot(DieClip);
            
        }
        


    }

    //씬 초기화
    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

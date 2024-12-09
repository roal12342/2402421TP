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

    
    public float maxSpeed;  //�÷��̾� �ִ�ӵ� ����
    public float jumpPower;  //�÷��̾� ������
    public bool playerFall = false;  //�÷��̾� ����
    public bool playerDie = false;  //�÷��̾� ���
    public bool timeOver = false;  //Ÿ�ӿ����� ���, TimeDirector ��ũ��Ʈ���� ����

    public AudioSource audioSource;     
    public AudioClip jumpClip;        //���� ����  
    public AudioClip DieClip;          // ��� ����

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
        //����
        if (Input.GetButtonUp("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            audioSource.PlayOneShot(jumpClip);
        }

        //����
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //�¿캯ȯ
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
        if (timeOver) //Ÿ�ӿ�����
        {
            timeOver = false; //Ÿ�ӿ��� ���� �ߺ� �ȵǰ�
            audioSource.PlayOneShot(DieClip); //��� ����
        }
    }
    IEnumerator PauseAndResume(float pauseDuration)
    {
        Time.timeScale = 0;  // ���� �Ͻ� ����
        yield return new WaitForSecondsRealtime(pauseDuration);  // ���� �ð��� �������� ��ٸ�
        Time.timeScale = 1;  // ���� �簳
        loadScene();
    }

    
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // ���� �Է� ��
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // �������� �̵�

        if(rigid.velocity.x > maxSpeed) //�ִ�ӵ� ����
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed*(-1))
        {
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }

        //����
        if(rigid.velocity.y <= 0) // �÷��̾ �ϰ��ϰų� ������ ����
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform")); // ĳ���� �Ʒ��� Raycast�� ���� "Platform" layer�� ���� ������Ʈ ����

            if (rayHit.collider != null) // Raycast�� ��� �÷����� �����Ѱ��
            {
                if (rayHit.distance < 0.6f) // ���� �Ÿ� 0.6 �̸��̸�
                {
                    anim.SetBool("isJumping", false); //isJumping ���� �ִϸ��̼��� false�� ����
                }
            }
        }

        // ����
        if (transform.position.y < -3 && !playerFall)
        {
            playerFall = true;
            audioSource.PlayOneShot(DieClip);
            Invoke("loadScene", 2f);
        }

        
        

    }

    
    //�浹����
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Train") // �浹�� ��ü �±װ� "Train"�� ��
        {
            SceneManager.LoadScene("Game222"); // "Game222"������ �̵�
        }
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("End");
        }
        if (collision.gameObject.tag == "Enemy") // �浹�� ��ü �±װ� "Enemy"�� ��
        {
            playerDie = true;
        }
        if (playerDie)
        {
            audioSource.PlayOneShot(DieClip);
            
        }
        


    }

    //�� �ʱ�ȭ
    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

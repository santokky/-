using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float gravityScale; //1.0f;
    public float jumpForce; //15.0f;

    public AudioClip[] audioclip;
    AudioSource audiosource;

    bool isJump = false;
    
    private Rigidbody2D rb;
    
    Animator ani1;
    AnimatorStateInfo aniState;

    BoxCollider2D col1;
    float colX, colY;

    void Start()
    {
        audiosource = transform.GetComponent<AudioSource>();

        gravityScale = GameManager.instance.gravityScale;//1.0f;
        jumpForce = GameManager.instance.jumpForce; //15.0f;

        rb = GetComponent<Rigidbody2D>();

        ani1 = transform.GetComponent<Animator>();
        col1 = transform.GetComponent<BoxCollider2D>();

        colX = col1.size.x;
        colY = col1.size.y;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Jump();
        }
            Slide();

        if (rb.velocity.y <= -5f)
        {
            land();
        }
    }


    void Jump()
    {
        if (!ani1.GetBool("isSlide") && IsCurrentAnimation("Run"))
        {
            audiosource.clip = audioclip[0];
            audiosource.Play();
            
            resetTriggers();

            //점프 힘을 주고, 점프 애니메이션 적용 후 점프 찬스를 줄인다.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            ani1.SetTrigger("isJumping");

            isJump = true;
        }
        else if (isJump && (IsCurrentAnimation("Jump") || IsCurrentAnimation("Land"))) {
            doubleJump();
        }
    }

    void doubleJump()
    {
        audiosource.clip = audioclip[0];
        audiosource.Play();
        
        isJump = false;

        resetTriggers();

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        ani1.SetTrigger("isDoubleJumping");
    }

    void Slide()
    {
        if (Input.GetMouseButtonDown(1) && IsCurrentAnimation("Run") && Time.timeScale != 0)
        {
            audiosource.clip = audioclip[1];
            audiosource.Play();
            
            ani1.SetBool("isSlide", true);
            col1.size = new Vector2(colY, colX);
        }
        else if (Input.GetMouseButtonUp(1) && IsCurrentAnimation("Slide") && Time.timeScale != 0)
        {
            ani1.SetBool("isSlide", false);
            col1.size = new Vector2(colX, colY);
        }
    }

    void land()
    {
        resetTriggers();

        ani1.SetTrigger("isLanding");
    }

    private bool IsCurrentAnimation(string animationName)
    {
        AnimatorStateInfo stateInfo = ani1.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName);
    }

    void resetTriggers() {
        ani1.ResetTrigger("isLanding");
        ani1.ResetTrigger("isWalking");
        ani1.ResetTrigger("isJumping");
        ani1.ResetTrigger("isDoubleJumping");
    }

    void FixedUpdate()
    {
        // 중력 적용
        Vector2 customGravity = Vector2.down * 9.81f * gravityScale;
        rb.AddForce(customGravity, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D ground)
    {
        if (ground.collider.CompareTag("Ground"))
        {
            resetTriggers();

            //땅과 맞닿는다면 걷는 애니메이션 재생
            ani1.SetTrigger("isWalking");
        }
    }

}

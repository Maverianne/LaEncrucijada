using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public BossHealth Boss;

    [Header("Camera Bound")]
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    public bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSPeed = 10f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;
    public AudioSource jump; 

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;
    public GameObject characterHolder;
    public bool Walk;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;

    [Header("Fight")]
    public bool canAttack;
    public bool bossFight;
    public bool dontFight;
    public bool coolDown;
    public void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (GameManager.instance.currentStrenght <= 30 && bossFight == false || GameManager.instance.currentSleep <= 30 && bossFight == false)
        {
            maxSpeed = 4f;
            jumpSPeed = 8f;
        }
        else
        {
            maxSpeed = 10f;
            jumpSPeed = 10f;
        }
        if (Walk)
        {
            maxSpeed = 6f;
            jumpSPeed = 0; 
        }
        bool wasOnGround = onGround;
        if(wasOnGround == false)
        {
            animator.SetBool("falling", true);           
        }
        else
        {
            animator.SetBool("falling",false);
        }
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        if (!wasOnGround && onGround)
        {
            StartCoroutine(JumpSqueeze(1.25f, .8f, 0.05f));
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
            jump.Play();
            animator.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.E) && onGround == true )
        {
            animator.SetTrigger("attack");
            //coolDown = false;
            //StartCoroutine("Cooling");
            if (bossFight)
            {
                maxSpeed = 10f;
                jumpSPeed = 12f;
                {
                    if (canAttack && BossHealth.instance.Invincible == false)
                    {
                        BossHealth.instance.currentHealth -= 4;
                        print("HitBoss");
                        canAttack = false;
                        StartCoroutine("AttackAgain");
                    }
                }
            }
        }
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
   
    private void FixedUpdate()
    {
        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }
        moveCharacter(direction.x);
        modifyPhysics();
    }

    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical", Mathf.Abs(rb.velocity.y));

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x)> maxSpeed){
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }
    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);
        if (onGround) { 
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections) 
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;

            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
              
            }
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSPeed, ForceMode2D.Impulse);
        jumpTimer = 0;
        StartCoroutine(JumpSqueeze(0.8f, 1.25f, 0.05f));
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }

    }
    IEnumerator AttackAgain()
    {
        yield return new WaitForSeconds(1);
        canAttack = true;
    }
    IEnumerator Cooling()
    {
        yield return new WaitForSeconds(1);
        coolDown = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            canAttack = false;
        }
     }
}


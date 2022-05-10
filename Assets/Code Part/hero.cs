using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    public Animator animator;
    public Transform attackPoint;
    public int attackDamage=40;
    public float attackRange = 0.8f;
    public LayerMask enemyLayers;
    public int life = 5;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;

    private SpriteRenderer spr;
    private bool facingLeft = false;
    private Animator anim;
    [SerializeField] Vector2 deathKick = new Vector2 (25f,25f);

    bool isAlive = true;
    
    
    //jump 
    public Transform CheckGround;
    public LayerMask GroundMask;
    
    private bool wasGrounded = false;

    private bool isJumping = false;
    public float JumpSpeed = 1f;
    public bool isGrounded = false;

    public int coinValue = 1;

    public Transform keyFollowPoint;
    

    
    
    
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("walking",false);

    }

    
    void Update()
    {
        if(!isAlive){return;}
        CheckInput();
        PlayerAnimation();
        CheckisGrounded();
        PlayerMove();
        GetHit();
        if(Input.GetMouseButtonDown(1))
        {
            Attack();
        }
        
    }
    





    private void CheckInput()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"),0f).normalized;
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
        }
        FlipSprite();

    }
    
    private void CheckisGrounded()
    {
        Collider2D col = null;
        wasGrounded = isGrounded;
        isGrounded = false;
      
        col = Physics2D.OverlapCircle(CheckGround.position,0.1f,GroundMask);
        if(col!= null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
    
    private void FlipSprite()
    {
        if(movement.x <0)
        {
            facingLeft = true;
        }
        else if(movement.x>0)
        {
            facingLeft = false;
        }
        spr.flipX = facingLeft;
    }
    private void PlayerJump()
    {
        if(isJumping && isGrounded)
        {
            movement.y = JumpSpeed;
        }
        if(!wasGrounded && isGrounded)
        {
            isJumping = false;
        }
    }
    private void PlayerMove()
    {
       movement *=speed;
       PlayerJump();
      movement.y += rb.velocity.y;
     
      rb.velocity = movement;
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coins"))
        {
            AudioSource.PlayClipAtPoint(coinPickUpSFX,Camera.main.transform.position);
            Destroy(collision.gameObject);

             
           
        }
    }
    
    private void PlayerAnimation()
    {
        if(movement.x!=0f)
        {
            anim.SetBool("walking",true);
        }
        else
        {
            anim.SetBool("walking",false);
        }
    }
    private void GetHit()
    {
        if(rb.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            anim.SetBool("gethit",true);
        }
        else
        {
            anim.SetBool("gethit",false);
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint ==  null)
        {
            return;
        }
      Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    

}

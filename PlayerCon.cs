using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{   
    public float Speed;
    public float jumpForce;
    private float moveInput;
    private Animator anim;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int Health = 5;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate(){
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        if (facingRight == true && moveInput < 0){
            Flip();
        }
        else if(facingRight == false && moveInput > 0){
            Flip();
        }
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)){
            
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("IsRunning", true);
        }    
        else{
            anim.SetBool("IsRunning", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            anim.SetTrigger("Jump");    
        }
    }
    void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void TakeDamage(int damage){
       Health -= damage;
       if(Health <= 0){
           Die();
       }
    }    
    void Die(){
        Destroy(gameObject);
    }
}

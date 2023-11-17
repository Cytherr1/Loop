using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed, minSpeed, jumpSpeed;
    private float tempSpeed;
    public float jumpPower;
    private Rigidbody2D rb;
    private bool isGrounded;
    public GameObject jumpPoint;
    float jumpTimer = 0f;
    public float gravityMultiplier;
    public Animator anim;
    bool jump;
    float timer = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempSpeed = maxSpeed;
    }
    private void Update()
    {
        Movement();
        Jump();
        isGrounded = jumpPoint.GetComponent<JumpPoint>().isGrounded;
    }

    void Movement()
    {
        // sağa sola hareket ve dönme
        Vector2 control = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetKey(KeyCode.A))
        {
            maxSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Abs(Input.GetAxis("Horizontal")));
            transform.rotation = Quaternion.Euler(0, -180, 0);
            transform.Translate(control * maxSpeed * Time.deltaTime * -1);
            
            anim.SetBool("run", true);
           
        }
        else if (Input.GetKey(KeyCode.D))
        {
            maxSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Abs(Input.GetAxis("Horizontal")));
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(control * maxSpeed * Time.deltaTime * 1);
           
            anim.SetBool("run", true);
            anim.SetBool("fall", false);

        }
        else
        {
            maxSpeed = tempSpeed;
            anim.SetBool("run", false);
            anim.SetBool ("fall", false);
        }
    }
    void Jump()
    {
        //zıplama
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
            anim.SetBool("jump",true);
            anim.SetBool("run", false);

        }
        if (jump)
        {
            timer += Time.deltaTime;
            anim.SetBool("run", false);
        }
        if (timer > 0.3f) 
        {
            anim.SetBool("run", false);
            rb.AddForce(Vector2.up * jumpPower / 10, ForceMode2D.Impulse);
            isGrounded = false;
            timer = 0;
            jump = false;
        }
        if (isGrounded && !jump)
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
        if (!isGrounded && !jump)
        {
            anim.SetBool("fall", true);
        }
        if (isGrounded)
        {
            anim.SetBool ("fall", false);   
        }
        if (!isGrounded)
        {
            maxSpeed = jumpSpeed;
            jumpTimer += Time.deltaTime;
            anim.SetBool("run", false);
        }
        else
        {
            maxSpeed = tempSpeed;
            jumpTimer = 0;
            rb.gravityScale = 1.0f;
        }
        // gravity

        if (jumpTimer > 0f)
        {
            rb.gravityScale = jumpTimer * gravityMultiplier;
        }
        else
        {
            rb.gravityScale = 1.0f;
        }
        if (rb.gravityScale > 6f)
        {
            rb.gravityScale = 6.1f;
        }
    }
}

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
        Animator();
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
        }
        else if (Input.GetKey(KeyCode.D))
        {
            maxSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Abs(Input.GetAxis("Horizontal")));
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(control * maxSpeed * Time.deltaTime * 1);
        }
        else
        {
            maxSpeed = tempSpeed;
        }
    }
    void Jump()
    {
        //zıplama

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower / 10, ForceMode2D.Impulse);
            isGrounded = false;

        }
        if (!isGrounded)
        {
            maxSpeed = jumpSpeed;
            jumpTimer += Time.deltaTime;
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
    void Animator()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
    }
}

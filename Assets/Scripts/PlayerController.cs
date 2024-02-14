using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

    bool isGrounded = false;

    float direction = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move(direction);
    }

    
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }


    private void OnMove(InputValue moveVal)
    {
        float moveDirection = moveVal.Get<float>();
        direction = moveDirection;
        
    }

    private void Move(float x)
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 norm = collision.GetContact(0).normal;
        if (Vector3.Angle(norm, Vector3.up) < 45f)
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    Rigidbody2D rb;
    [SerializeField] float speed = 5f;

    bool isGrounded = false;
    // [SerializeField] float jumpHeight = 5f;



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

    
   

    private void OnMove(InputValue moveVal)
    {
        Vector2 moveDirection = moveVal.Get<Vector2>();
        direction = moveDirection.x;
        Debug.Log(moveDirection);
        
    }

    private void Move(float x)
    {

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 norm = collision.GetContact(0).normal;
        if (Vector2.Angle(norm, Vector2.up) < 45f)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;

    Vector2 direction;

    bool isGrounded = false;
    // [SerializeField] float jumpHeight = 5f;

    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       Move(direction);
        if (isFacingRight && direction.x < 0 || (!isFacingRight && direction.x > 0))
        {
            Flip();
        }
    }

    private void OnMove(InputValue moveVal)
    {
        Vector2 moveDirection = moveVal.Get<Vector2>();
        direction = moveDirection;
    }

    private void Move(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newLocalScale = transform.localScale;
        newLocalScale.x *= -1f;
        transform.localScale = newLocalScale;
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

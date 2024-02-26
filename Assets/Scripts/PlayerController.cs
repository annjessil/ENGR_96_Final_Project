using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float speed = 5f;
    Vector2 direction;
    bool isFacingRight = true;
    public VectorValue startingPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = startingPosition.initialValue;

    }

    // Update is called once per frame
    public void Update()
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
        anim.SetBool("isRunning", dir.magnitude != 0);
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
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

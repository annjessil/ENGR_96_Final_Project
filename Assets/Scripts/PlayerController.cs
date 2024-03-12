using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] public float speed = 5f;
    Vector2 direction;
    bool isFacingRight = true;
    public LayerMask interactableLayer;
    float badSpeedBonusRange, goodSpeedBonusRange;

    


    //public VectorValue startingPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //  transform.position = startingPosition.initialValue; // null reference error 
        //speed Buff
        
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        Move(direction);
        if (isFacingRight && direction.x < 0 || (!isFacingRight && direction.x > 0))
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

    }

    private void OnMove(InputValue moveVal)
    {
        Vector2 moveDirection = moveVal.Get<Vector2>();
        direction = moveDirection;
    }

    private void Interact() {
        var collider = Physics2D.OverlapCircle(transform.position, 1f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactables>()?.Interact();
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        badSpeedBonusRange = Random.Range(-4f, -1f);
        goodSpeedBonusRange = Random.Range(1f, 10f);

        if (collision.gameObject.tag == "Collectable")
        {
            StartCoroutine(speedBuff(goodSpeedBonusRange));
        }

        if (collision.gameObject.tag == "BadCollectable")
        {
            StartCoroutine(speedBuff(badSpeedBonusRange));
        }
    }



    IEnumerator speedBuff(float speedBonus)
    {
        speed += speedBonus;
        Debug.Log("before");

        yield return new WaitForSeconds(7);
        Debug.Log("after");

        // Remove buff effects after duration
        speed -= speedBonus;

    }


}

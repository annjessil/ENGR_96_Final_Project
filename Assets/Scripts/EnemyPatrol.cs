using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public GameObject Player;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private Transform playerPos;
    public float speed;
    public float chaseSpeed;
    public float chaseDistance;
    public bool isChasing;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        playerPos = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerPos.position - transform.position;
        if (isChasing)
        {
            if (transform.position.x < playerPos.position.x)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            if (transform.position.x > playerPos.position.x)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            direction.Normalize();
            movement = direction;
            moveCharacter(movement);
        }
        else
        {
            if (Vector2.Distance(transform.position, playerPos.position) < chaseDistance)
            {
                isChasing = true;
            }
             
            if (currentPoint == PointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);

            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
            {
                flip();
                currentPoint = PointA.transform;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
            {
                flip();
                currentPoint = PointB.transform;
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * chaseSpeed * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform playerPos;
    public Transform[] patrolPoints;
    public float speed;
    public int patrolDestination;
    public float chaseSpeed;
    public float chaseDistance;
    public float loseDistance;
    public bool isChasing;
    private Vector2 movement;
    private Vector2 movementPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerPos = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionPlayer = playerPos.position - transform.position;

        if (isChasing)
        {
            if (directionPlayer.magnitude > loseDistance)
            {
                isChasing = false;
            }

            if (transform.position.x < playerPos.position.x)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            if (transform.position.x > playerPos.position.x)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            directionPlayer.Normalize();
            movement = directionPlayer;
            moveCharacter(movement);
        }
        else
        {
            if (Vector2.Distance(transform.position, playerPos.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(2, 2, 2);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-2, 2, 2);
                    patrolDestination = 0;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(patrolPoints[0].transform.position, 0.5f);
        Gizmos.DrawWireSphere(patrolPoints[1].transform.position, 0.5f);
        Gizmos.DrawLine(patrolPoints[0].transform.position, patrolPoints[1].transform.position);
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

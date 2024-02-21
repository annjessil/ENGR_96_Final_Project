using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 5f;
    float move = 0f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * runSpeed;
        move = Input.GetAxisRaw("Vertical") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(move));
    }
}

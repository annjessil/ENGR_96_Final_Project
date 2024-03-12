using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoor_Speed_Debuff : MonoBehaviour
{ 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

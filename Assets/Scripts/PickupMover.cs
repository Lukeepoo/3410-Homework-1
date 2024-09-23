//Lucas Lovellette
//09/21/2024
// PickupMover.cs
// Moves pickup objects randomly and changes their direction upon collision.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMover : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 newVelocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
        rb2d.velocity = newVelocity; // Bounce off in random direction
    }
}

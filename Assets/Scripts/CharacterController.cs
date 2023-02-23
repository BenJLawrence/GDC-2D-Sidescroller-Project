using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float acceleration = 400f;
    public float maxSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
        FlipSprite();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }

        rb.AddForce(movement * acceleration * Time.deltaTime, ForceMode2D.Force);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void FlipSprite()
    {
        if (rb.velocity.x > 0)
        {
            sprite.flipX = false;
        }

        if (rb.velocity.x < 0)
        {
            sprite.flipX = true;
        }
    }
}

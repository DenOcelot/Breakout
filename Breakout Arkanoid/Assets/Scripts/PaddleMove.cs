using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),0);
        moveVelocity = moveInput * speed;


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            sprite.flipX = !sprite.flipX;
            SpriteRenderer renderer = collision.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = renderer.color;
        }

        if(collision.gameObject.tag == "+")
        {
            transform.localScale += new Vector3(0.2f, 0.0f, 0.0f); ;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "-")
        {
            transform.localScale -= new Vector3(0.2f, 0.0f, 0.0f); ;
            Destroy(collision.gameObject);
        }
    }

}

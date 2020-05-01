using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Light light;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 0.0f, Random.Range(-20f,20f));
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        sprite = GetComponent<SpriteRenderer>();
        light = GetComponent<Light>();
        transform.Rotate(0f, 0.0f, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            light.enabled = true;
            SpriteRenderer renderer = collision.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = renderer.color;
            light.color = sprite.color;
        }
        if(collision.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }
}

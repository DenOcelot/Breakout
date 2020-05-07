using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Effect;
    SpriteRenderer sprite;
    Light light;
    ParticleSystem em;
    Color color;
    int num;

    public GameObject plus;
    public GameObject minus;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        light = GetComponent<Light>();
        num = Random.Range(1, 6);
        if (num == 1)
        {
            Destroy(gameObject);
        }
        if (num == 2)
        {
            color = Color.blue;
        }
        if (num == 3)
        {
            color = Color.green;
        }
        if (num == 4)
        {
            color = Color.red;
        }
        if (num == 5)
        {
            color = Color.yellow;
        }
        sprite.color = color;
        light.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {      
        GameObject brek = Instantiate(Effect, transform.position, transform.rotation);
        em = brek.GetComponent<ParticleSystem>();
        em.startColor = color;
        num = Random.Range(1, 6);
        if (num == 1)
        {
            Instantiate(plus, transform.position, transform.rotation);
        }
        if (num == 2)
        {
            Instantiate(minus, transform.position, transform.rotation);
        }
        Destroy(gameObject);       
    }
}

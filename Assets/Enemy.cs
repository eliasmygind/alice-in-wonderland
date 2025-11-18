using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 5;
    Rigidbody2D rb;
    public Boolean right = false;
    public Boolean left = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        if (transform.position.x > target.position.x)
        {
            right = true;
        }
        if (transform.position.x < target.position.x)
        {
            left = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (right == true) 
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        if (left == true) 
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
    }
}

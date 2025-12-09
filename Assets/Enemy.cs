using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float canMove = 15;
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
        Destroy(gameObject, 17f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove > 0)
        {
            if (right == true)
            {
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            }

            if (left == true)
            {
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            }
            canMove -= Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
       
    }
}

using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 5;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > target.position.x) 
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        if (transform.position.x < target.position.x) 
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
    }
}

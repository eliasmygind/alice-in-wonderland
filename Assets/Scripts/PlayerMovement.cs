using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower = 10f;
    public float speed = 5f;

    public Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public GameObject playerArrow;
    public float playerArrowSpeed = 10f;
    public float arrowCooldown = 0.5f;
    private float nextFireTime;
   

    private bool isFacingRight = true;

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, whatIsGround);

        // Movement
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            isFacingRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            isFacingRight = true;
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

        // Short hop
        if (Input.GetKeyUp(KeyCode.W) && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        // Fall reset
        if (transform.position.y < -15f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootArrow();
            nextFireTime = Time.time + arrowCooldown;
        }
    }

    void ShootArrow()
    {
        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;

        GameObject arrow = Instantiate(
            playerArrow,
            transform.position + (Vector3)(direction * 1f),
            Quaternion.identity
        );

        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        arrowRb.linearVelocity = direction * playerArrowSpeed;
    }
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

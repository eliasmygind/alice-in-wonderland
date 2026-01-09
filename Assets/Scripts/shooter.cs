using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float arrowSpeed = 10f;
    public float shootDelay = 2f;
    void Start()
    {
        InvokeRepeating(nameof(ShootArrow), 0f, shootDelay);
    }

    void ShootArrow()
    {

        GameObject arrow = Instantiate(
            arrowPrefab,
            transform.position + transform.right * 1f,
            transform.rotation
        );

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(10, 0);
    }
}
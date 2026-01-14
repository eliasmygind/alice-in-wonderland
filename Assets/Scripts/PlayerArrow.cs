using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerArrow : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("arrow shooter"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }


    }
}

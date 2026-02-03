using UnityEngine;
using UnityEngine.SceneManagement;

public class resetGame : MonoBehaviour
{
    public void ResstLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

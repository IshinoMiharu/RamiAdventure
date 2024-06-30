using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{

    public string sceneName; // Ø‚è‘Ö‚¦æ‚ÌƒV[ƒ“–¼



void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerMove>().hasKey)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
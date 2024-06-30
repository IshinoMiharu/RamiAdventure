using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{

    public string sceneName; // 切り替え先のシーン名



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
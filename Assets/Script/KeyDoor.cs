using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{

    public string sceneName; // �؂�ւ���̃V�[����



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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObject : MonoBehaviour
{
    public string sceneName; // Ø‚è‘Ö‚¦æ‚ÌƒV[ƒ“–¼

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
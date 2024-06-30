using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // 切り替え先のシーン名

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 指定されたシーンに切り替える
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }
    }
}

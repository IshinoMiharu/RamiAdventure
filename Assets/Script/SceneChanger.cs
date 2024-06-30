using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // �؂�ւ���̃V�[����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �w�肳�ꂽ�V�[���ɐ؂�ւ���
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }
    }
}

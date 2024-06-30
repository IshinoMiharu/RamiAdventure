using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;  // �|�[�Y�p�l��������

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Title")
        {
            ResumeGame();
        }

    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;  // �Q�[���̎��Ԃ��~
        isPaused = true;
        



    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;  // �Q�[���̎��Ԃ��ĊJ
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        // ���C�����j���[�ɖ߂鏈���i�K�X�ݒ�j
        Time.timeScale = 1f;  // �Q�[���̎��Ԃ��ĊJ���Ă���
        // SceneManager.LoadScene("MainMenu");  // �V�[���J�ڂ̗�
    }

}
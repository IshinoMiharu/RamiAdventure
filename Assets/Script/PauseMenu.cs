using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;  // ポーズパネルを入れる

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
        Time.timeScale = 0f;  // ゲームの時間を停止
        isPaused = true;
        



    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;  // ゲームの時間を再開
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        // メインメニューに戻る処理（適宜設定）
        Time.timeScale = 1f;  // ゲームの時間を再開しておく
        // SceneManager.LoadScene("MainMenu");  // シーン遷移の例
    }

}
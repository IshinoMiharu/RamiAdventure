using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    //現在のシーンを再度読み込む処理
    //ゲームオーバー、リトライ時に読み込めるようにしたい
    public GameObject pausePanel;
    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Stage1")
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene("Stage1");
        }
        else if (currentSceneName == "Stage2")
        {
            SceneManager.LoadScene("Stage2");
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
        else if (currentSceneName == "Stage3")
        {
            SceneManager.LoadScene("Stage3");
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
        else if (currentSceneName == "Stage4")
        {
            SceneManager.LoadScene("Stage4");
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }
}
    
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    //���݂̃V�[�����ēx�ǂݍ��ޏ���
    //�Q�[���I�[�o�[�A���g���C���ɓǂݍ��߂�悤�ɂ�����
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
    
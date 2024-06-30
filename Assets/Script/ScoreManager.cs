using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;
    private HashSet<string> collectedCoins = new HashSet<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �V�[���J�n���� "ScoreText" �I�u�W�F�N�g��T���ăA�^�b�`����
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        UpdateScoreText();
    }

    public void AddScore(int value, string coinID)
    {
        if (!collectedCoins.Contains(coinID))
        {
            score += value;
            collectedCoins.Add(coinID);
            UpdateScoreText();
        }
    }

    public bool HasCollectedCoin(string coinID)
    {
        return collectedCoins.Contains(coinID);
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            
            scoreText.text = "�݂ւ���R�C��: " + score.ToString();
        }
    }

    public void ResetScore()
    {
        score = 0;
        collectedCoins.Clear();
        UpdateScoreText();
    }
}

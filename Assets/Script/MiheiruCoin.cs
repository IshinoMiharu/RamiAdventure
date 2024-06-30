using UnityEngine;

public class MiheiruCoin : MonoBehaviour
{
    public int coinValue = 1;
    public string coinID;

    private void Start()
    {
        if (ScoreManager.instance.HasCollectedCoin(coinID))
        {
            Destroy(gameObject); // 既に収集されたコインは破壊する
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // スコアを追加
            ScoreManager.instance.AddScore(coinValue, coinID);
            // コインを破壊
            Destroy(gameObject);
        }
    }
}

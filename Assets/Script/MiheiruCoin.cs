using UnityEngine;

public class MiheiruCoin : MonoBehaviour
{
    public int coinValue = 1;
    public string coinID;

    private void Start()
    {
        if (ScoreManager.instance.HasCollectedCoin(coinID))
        {
            Destroy(gameObject); // ���Ɏ��W���ꂽ�R�C���͔j�󂷂�
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �X�R�A��ǉ�
            ScoreManager.instance.AddScore(coinValue, coinID);
            // �R�C����j��
            Destroy(gameObject);
        }
    }
}

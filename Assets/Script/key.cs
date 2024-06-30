using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーがカギを取得
            other.GetComponent<PlayerMove>().hasKey = true;

            // カギのオブジェクトを破壊
            Destroy(gameObject);
        }
    }
}
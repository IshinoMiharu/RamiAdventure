using UnityEngine;

public class PlayerFallDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; // PlayerHealthスクリプトへの参照
    public float fallDamageThreshold = 10f; // ダメージを受ける落下速度の閾値
    public float damageMultiplier = 2f; // 落下速度に対するダメージの倍率

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // プレイヤーの健康スクリプトへの参照が設定されていない場合、同じオブジェクトから取得します
        if (playerHealth == null)
        {
            playerHealth = GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        // 落下速度のデバッグ
       //Debug.Log("Current vertical speed: " + rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // 地面と衝突した場合
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("地面に衝突");

            // 縦の速度が一定の閾値を超えているか確認
            float fallSpeed = Mathf.Abs(rb.velocity.y);
            Debug.Log("フルスピード: " + fallSpeed);

            if (fallSpeed > fallDamageThreshold)
            {
                // ダメージを計算
                int damage = Mathf.RoundToInt((fallSpeed - fallDamageThreshold) * damageMultiplier);
                Debug.Log("落下ダメージ: " + damage);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
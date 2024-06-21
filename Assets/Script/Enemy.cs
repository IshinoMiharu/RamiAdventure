using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public float chaseRange = 5f;  // 敵がプレイヤーを追いかける範囲
    public float moveSpeed = 2f;  // 敵の移動速度

    private bool isChasing = false;

    void Update()
    {
        // プレイヤーと敵の距離を計算
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            // プレイヤーが範囲内にいる場合、追跡を開始
            isChasing = true;
        }
        else
        {
            // プレイヤーが範囲外にいる場合、追跡を停止
            isChasing = false;
        }

        if (isChasing)
        {
            // プレイヤーの方に向かって移動
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    // デバッグ用に範囲をギズモで表示
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

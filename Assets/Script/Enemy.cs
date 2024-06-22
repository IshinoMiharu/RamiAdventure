using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public float chaseRange = 5f;  // 敵がプレイヤーを追いかける範囲
    public float moveSpeed = 2f;  // 敵の移動速度

    public int maxHP = 100;  // 敵の最大HP
    private int currentHP;  // 敵の現在のHP
    private SpriteRenderer spriteRenderer;
    private Vector2 originalPosition;  // 敵の元の位置
    public Transform[] patrolPoints;  // パトロールするポイントの配列
    public float StaySpeed = 2f;  // 移動速度
    private int currentPointIndex = 0;  // 現在のポイントのインデックス


    private bool isChasing = false;
   // private bool lookPlayer = false;

    void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
    }

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
        else
        {
            // 元の位置に戻る
            //transform.position = Vector2.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }

        //パトロール
        {
            if (!isChasing)
            {
                if (patrolPoints.Length == 0)
                    return;

                // 現在のターゲットポイント
                Transform targetPoint = patrolPoints[currentPointIndex];

                // ターゲットポイントに向かって移動
                transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

                // ターゲットポイントに到達した場合、次のポイントに移動
                if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
                {
                    currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                }
            }

        }
    }

    // デバッグ用に範囲をギズモで表示
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    // 攻撃を受けた時に呼ばれるメソッド
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        spriteRenderer.color = Color.red;

        // HPが0以下になったら敵を破壊
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            // 一定時間後に元の色に戻す
            Invoke("ResetColor", 0.2f);
        }
    }

    // 色を元に戻すメソッド
    void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "barrette")
        {

            TakeDamage(1);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Gizmos.DrawSphere(patrolPoints[i].position, 0.2f);
            if (i < patrolPoints.Length - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position);
            }
        }
        if (patrolPoints.Length > 1)
        {
            Gizmos.DrawLine(patrolPoints[patrolPoints.Length - 1].position, patrolPoints[0].position);
        }
    }
}



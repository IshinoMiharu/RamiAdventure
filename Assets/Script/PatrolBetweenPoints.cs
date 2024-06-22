using UnityEngine;

public class PatrolBetweenPoints : MonoBehaviour
{
    public Transform[] patrolPoints;  // パトロールするポイントの配列
    public float moveSpeed = 2f;  // 移動速度
    private int currentPointIndex = 0;  // 現在のポイントのインデックス

    void Update()
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

    // パトロールポイントをギズモで表示
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
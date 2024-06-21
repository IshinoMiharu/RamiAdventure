using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public float chaseRange = 5f;  // �G���v���C���[��ǂ�������͈�
    public float moveSpeed = 2f;  // �G�̈ړ����x

    private bool isChasing = false;

    void Update()
    {
        // �v���C���[�ƓG�̋������v�Z
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            // �v���C���[���͈͓��ɂ���ꍇ�A�ǐՂ��J�n
            isChasing = true;
        }
        else
        {
            // �v���C���[���͈͊O�ɂ���ꍇ�A�ǐՂ��~
            isChasing = false;
        }

        if (isChasing)
        {
            // �v���C���[�̕��Ɍ������Ĉړ�
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    // �f�o�b�O�p�ɔ͈͂��M�Y���ŕ\��
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

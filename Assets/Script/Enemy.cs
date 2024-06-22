using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public float chaseRange = 5f;  // �G���v���C���[��ǂ�������͈�
    public float moveSpeed = 2f;  // �G�̈ړ����x

    public int maxHP = 100;  // �G�̍ő�HP
    private int currentHP;  // �G�̌��݂�HP
    private SpriteRenderer spriteRenderer;
    private Vector2 originalPosition;  // �G�̌��̈ʒu
    public Transform[] patrolPoints;  // �p�g���[������|�C���g�̔z��
    public float StaySpeed = 2f;  // �ړ����x
    private int currentPointIndex = 0;  // ���݂̃|�C���g�̃C���f�b�N�X


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
        else
        {
            // ���̈ʒu�ɖ߂�
            //transform.position = Vector2.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }

        //�p�g���[��
        {
            if (!isChasing)
            {
                if (patrolPoints.Length == 0)
                    return;

                // ���݂̃^�[�Q�b�g�|�C���g
                Transform targetPoint = patrolPoints[currentPointIndex];

                // �^�[�Q�b�g�|�C���g�Ɍ������Ĉړ�
                transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

                // �^�[�Q�b�g�|�C���g�ɓ��B�����ꍇ�A���̃|�C���g�Ɉړ�
                if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
                {
                    currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                }
            }

        }
    }

    // �f�o�b�O�p�ɔ͈͂��M�Y���ŕ\��
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    // �U�����󂯂����ɌĂ΂�郁�\�b�h
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        spriteRenderer.color = Color.red;

        // HP��0�ȉ��ɂȂ�����G��j��
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            // ��莞�Ԍ�Ɍ��̐F�ɖ߂�
            Invoke("ResetColor", 0.2f);
        }
    }

    // �F�����ɖ߂����\�b�h
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



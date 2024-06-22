using UnityEngine;

public class PatrolBetweenPoints : MonoBehaviour
{
    public Transform[] patrolPoints;  // �p�g���[������|�C���g�̔z��
    public float moveSpeed = 2f;  // �ړ����x
    private int currentPointIndex = 0;  // ���݂̃|�C���g�̃C���f�b�N�X

    void Update()
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

    // �p�g���[���|�C���g���M�Y���ŕ\��
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
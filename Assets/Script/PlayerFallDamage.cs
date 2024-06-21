using UnityEngine;

public class PlayerFallDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; // PlayerHealth�X�N���v�g�ւ̎Q��
    public float fallDamageThreshold = 10f; // �_���[�W���󂯂闎�����x��臒l
    public float damageMultiplier = 2f; // �������x�ɑ΂���_���[�W�̔{��

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �v���C���[�̌��N�X�N���v�g�ւ̎Q�Ƃ��ݒ肳��Ă��Ȃ��ꍇ�A�����I�u�W�F�N�g����擾���܂�
        if (playerHealth == null)
        {
            playerHealth = GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        // �������x�̃f�o�b�O
       //Debug.Log("Current vertical speed: " + rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // �n�ʂƏՓ˂����ꍇ
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("�n�ʂɏՓ�");

            // �c�̑��x������臒l�𒴂��Ă��邩�m�F
            float fallSpeed = Mathf.Abs(rb.velocity.y);
            Debug.Log("�t���X�s�[�h: " + fallSpeed);

            if (fallSpeed > fallDamageThreshold)
            {
                // �_���[�W���v�Z
                int damage = Mathf.RoundToInt((fallSpeed - fallDamageThreshold) * damageMultiplier);
                Debug.Log("�����_���[�W: " + damage);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
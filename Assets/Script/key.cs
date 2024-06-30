using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[���J�M���擾
            other.GetComponent<PlayerMove>().hasKey = true;

            // �J�M�̃I�u�W�F�N�g��j��
            Destroy(gameObject);
        }
    }
}
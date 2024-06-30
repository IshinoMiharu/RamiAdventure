using UnityEngine;

public class SpriteActivator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // ������ԂŔ�\��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true; // �v���C���[���G�ꂽ��\��
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
                if (other.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; // �v���C���[�����ꂽ���\��
            }
        }
    }
}

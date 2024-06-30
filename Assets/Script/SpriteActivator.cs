using UnityEngine;

public class SpriteActivator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // 初期状態で非表示
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true; // プレイヤーが触れたら表示
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
                if (other.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; // プレイヤーが離れたら非表示
            }
        }
    }
}

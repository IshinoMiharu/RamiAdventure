using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform destination; // 移動先のドア
    private bool isPlayerInDoorArea = false; // プレイヤーがドアの範囲内にいるかどうか

    private void Update()
    {
        if (isPlayerInDoorArea && Input.GetKeyDown(KeyCode.E))
        {
            // プレイヤーを移動先の位置に移動させる
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = destination.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInDoorArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInDoorArea = false;
        }
    }
}
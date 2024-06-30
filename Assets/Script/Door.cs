using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform destination; // �ړ���̃h�A
    private bool isPlayerInDoorArea = false; // �v���C���[���h�A�͈͓̔��ɂ��邩�ǂ���

    private void Update()
    {
        if (isPlayerInDoorArea && Input.GetKeyDown(KeyCode.E))
        {
            // �v���C���[���ړ���̈ʒu�Ɉړ�������
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
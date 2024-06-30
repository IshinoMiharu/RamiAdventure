using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{


        public string sceneName; // �؂�ւ���̃V�[����
    private bool isPlayerInDoorArea = false;


    void Start()
        {
        }

    private void Update()
    {
        if (isPlayerInDoorArea && Input.GetKeyDown(KeyCode.E))
        {
            // �v���C���[���ړ���̈ʒu�Ɉړ�������
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                    SceneManager.LoadScene(sceneName);
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


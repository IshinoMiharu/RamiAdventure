using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{


        public string sceneName; // 切り替え先のシーン名
    private bool isPlayerInDoorArea = false;


    void Start()
        {
        }

    private void Update()
    {
        if (isPlayerInDoorArea && Input.GetKeyDown(KeyCode.E))
        {
            // プレイヤーを移動先の位置に移動させる
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


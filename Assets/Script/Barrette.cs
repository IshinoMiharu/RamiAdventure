using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class barrette : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "BackGround" && collision.gameObject.tag != "Zerima" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Shot")
            Destroy(gameObject);
        //このゲームオブジェクトが背景やプレイヤー以外のTriggerに接触したとき破壊される。
    }

}

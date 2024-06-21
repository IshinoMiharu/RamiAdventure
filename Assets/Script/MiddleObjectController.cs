using UnityEngine;

public class MiddleObjectController : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    void Update()
    {
        if (objectA != null && objectB != null)
        {
            // ObjectA と ObjectB の中間地点を計算
            Vector3 middlePoint = (objectA.position + objectB.position) / 2;
            // 中間地点にこのオブジェクトを移動
            transform.position = middlePoint;
        }
    }
}
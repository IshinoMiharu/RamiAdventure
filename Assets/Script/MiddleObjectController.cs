using UnityEngine;

public class MiddleObjectController : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    void Update()
    {
        if (objectA != null && objectB != null)
        {
            // ObjectA �� ObjectB �̒��Ԓn�_���v�Z
            Vector3 middlePoint = (objectA.position + objectB.position) / 2;
            // ���Ԓn�_�ɂ��̃I�u�W�F�N�g���ړ�
            transform.position = middlePoint;
        }
    }
}
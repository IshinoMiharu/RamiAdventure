using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : ItemBase
{
    [SerializeField]GameObject _gameObject;
    public override void Activate()
    {
        ZerimaMove Ze = _gameObject.GetComponent<ZerimaMove>();
        Ze.Move(5f);
    }
}

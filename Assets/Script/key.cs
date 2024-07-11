using UnityEngine;

public class Key : ItemBase
{
    public override void Activate()
    {
        GetComponent<PlayerMove>().hasKey = true;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCrash : MonoBehaviour
{
    [SerializeField] string Tag; 
    public bool DontDestroyEnabled = true;
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Scene��J�ڂ��Ă������Ȃ�
            DontDestroyOnLoad(this);
        }
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(Tag);
            if (1 < objs.Length) Destroy(objs[1]);
        }
    }
}

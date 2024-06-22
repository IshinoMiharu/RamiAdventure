using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    GameObject offObject;

    // Start is called before the first frame update
    void Start()
    {
        offObject = GameObject.Find("Glass");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            Debug.Log("SwitchÅI");
            offObject .SetActive(false);
        }
    }
}

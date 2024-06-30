using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] string Crashobject;
    GameObject offObject;
    Animator animator;
    bool InPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        offObject = GameObject.Find(Crashobject);
        animator = GetComponent<Animator>();
        animator.SetBool("Switch", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InPlayer)
        {
            Debug.Log("SwitchÅI");
            offObject.SetActive(false);
            animator.SetBool("Switch", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InPlayer = false;
        }
        
    }
}

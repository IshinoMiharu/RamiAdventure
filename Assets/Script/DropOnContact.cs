using UnityEngine;

public class DropOnContact : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // freeze position‚ğ‰ğœ
                rb.constraints = RigidbodyConstraints2D.None;

            }


        }

    }
}
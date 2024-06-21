using UnityEngine;

/// <summary>
/// �K���}���̃L�����N�^�[�𑀍삷��R���|�[�l���g
/// </summary>
public class ZerimaMove : MonoBehaviour
{
    /// <summary>���E��    �������</summary>
    [SerializeField] float m_movePower = 3f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float m_jumpPower = 5f;
    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors �Ɏg���Y��</summary>
    int m_colorIndex;
    //int cokorCount = 0;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    float m_scaleX;
    /// <summary>�ŏ��ɏo���������W</summary>
    //Rigidbody2D _p_move = default;
    Vector3 m_initialPosition;

    public Transform groundCheck;   // �ڒn�����m���邽�߂̃I�u�W�F�N�g
    public LayerMask groundLayer;   // �n�ʂƔ��肷�郌�C���[
    GameObject r_object;

    private Rigidbody2D rb;

    public static bool muki = false;
    bool isGrounded = false;
    bool BigJump = false;
    Animator animator;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        r_object = GameObject.Find("Zerima");
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        // ���͂��󂯎��
        //m_h = Input.GetAxisRaw("Horizontal");

        // �e����͂��󂯎��
        // �ڒn���Ă��邩�ǂ��������m
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_h = -1;
            animator.SetBool("ZerimaMove", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("ZerimaMove", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_h = 1;
            animator.SetBool("ZerimaMove", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("ZerimaMove", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_h = 0;
        }

        m_rb.velocity = new Vector2(m_h * m_movePower, m_rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {

            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            isGrounded = false;

        }


        if (m_flipX)
        {
            FlipX(m_h);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)&& isGrounded)
        {
            animator.SetBool("ZerimaDw", true);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("ZerimaDw", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && BigJump)
        {
            Debug.Log("��W�����v�I");
            Rigidbody2D r_rb = r_object.GetComponent<Rigidbody2D>();
            r_rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            BigJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("touch�I");
            BigJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("touch�I");
            BigJump = false;
        }

    }

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="c">���������̓��͒l</param>
    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            m_sprite.flipX = false;
        }
        else if (horizontal < 0)
        {
            m_sprite.flipX = true;
        }
    }
}

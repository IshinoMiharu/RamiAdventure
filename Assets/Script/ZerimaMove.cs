using UnityEngine;

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class ZerimaMove : MonoBehaviour
{
    /// <summary>左右移    動する力</summary>
    [SerializeField] float m_movePower = 3f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 5f;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors に使う添字</summary>
    int m_colorIndex;
    //int cokorCount = 0;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    //Rigidbody2D _p_move = default;
    Vector3 m_initialPosition;

    public Transform groundCheck;   // 接地を検知するためのオブジェクト
    public LayerMask groundLayer;   // 地面と判定するレイヤー
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
        // 入力を受け取る
        //m_h = Input.GetAxisRaw("Horizontal");

        // 各種入力を受け取る
        // 接地しているかどうかを検知
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
            Debug.Log("大ジャンプ！");
            Rigidbody2D r_rb = r_object.GetComponent<Rigidbody2D>();
            r_rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            BigJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("touch！");
            BigJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("touch！");
            BigJump = false;
        }

    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="c">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
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

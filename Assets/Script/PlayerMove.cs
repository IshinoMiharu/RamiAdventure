using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �K���}���̃L�����N�^�[�𑀍삷��R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{

    [SerializeField] float m_movePower = 3f;    
    [SerializeField] float m_jumpPower = 5f;
    [SerializeField] bool m_flipX = false;
    [SerializeField] GameObject Zerima;
    [SerializeField] GameObject RidePoint;
    [SerializeField] GameObject ExetPoint;
    public bool hasKey = false;
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

    public bool muki = false;
    public Transform groundCheck;   // �ڒn�����m���邽�߂̃I�u�W�F�N�g
    public LayerMask groundLayer;   // �n�ʂƔ��肷�郌�C���[
    Animator animator;

    private Rigidbody2D rb;

    bool isGrounded = false;
    bool inZerima = false;
    bool _isrideZerima = false;
    public bool IsRideZerima
    {
        get { return _isrideZerima; }
    }

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }



    void Update()
    {

        // �e����͂��󂯎��
        // �ڒn���Ă��邩�ǂ��������m
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
          

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_h = -1;
            animator.SetBool("Dash",true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Dash", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_h = 1;
            animator.SetBool("Dash", true);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Dash", false);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            m_h = 0;
            animator.SetFloat("MoveHorizontal", m_h);
        }

        m_rb.velocity = new Vector2(m_h * m_movePower, m_rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {

            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Jump", false);
        }


        if (m_flipX)
        {
            FlipX(m_h);
        }

        if(inZerima&& Input.GetKeyUp(KeyCode.RightShift))
        {
            Zerima.transform.parent = this.transform;
            Zerima.GetComponent<Rigidbody2D>().simulated = false;
            Zerima.transform.position = RidePoint.transform.position;
            _isrideZerima = true;
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && _isrideZerima == true)
        {
            Debug.Log("�e�q�����I");
            _isrideZerima = false;
            Zerima.GetComponent<Rigidbody2D>().simulated = true;
            GameObject.Find("Zerima").transform.parent = null;
            // Zerima.GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            Zerima.transform.position = ExetPoint.transform.position;
            Zerima.GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zerima")
        {
            inZerima = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("Jump", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            ReloadScene();
        }
        if (collision.gameObject.tag == "Boss")
        {
            ReloadScene();
        }
        if (collision.gameObject.tag == "Toge")
        {
            ReloadScene();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zerima"&&inZerima)
        {
            inZerima = false;
        }

    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Stage1")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Stage1");
        }
        else if (currentSceneName == "Stage2")
        {
            SceneManager.LoadScene("Stage2");
            Time.timeScale = 1f;
        }
        else if (currentSceneName == "Stage3")
        {
            SceneManager.LoadScene("Stage3");
            Time.timeScale = 1f;
        }
        else if (currentSceneName == "Stage4")
        {
            SceneManager.LoadScene("Stage4");
            Time.timeScale = 1f;
        }
    }
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow) && inZerima == true)
    //    {
    //        Debug.Log("�e�q�����I");

    //        Zerima.GetComponent<Rigidbody2D>().simulated = true;
    //        GameObject.Find("Zerima").transform.parent = null;
    //        Zerima.GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
    //        Zerima.transform.position = RidePoint.transform.position;
    //        inZerima = false;
    //    }
    //   // Debug.Log(inZerima);
    //}

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="horizontal">���������̓��͒l</param>
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
            m_sprite.flipX=false;  
        }
        else if (horizontal < 0)
        {
            m_sprite.flipX = true;
        }
    }
}

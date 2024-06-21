using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] GameObject bulletPrefab; // �e�ۂ̃v���n�u
    [SerializeField] Transform bulletSpawnPoint; // �e�ۂ̐����ʒu
    [SerializeField] float bulletSpeed = 10f; // �e�ۂ̑��x
    [SerializeField] float fireRate = 0.5f; // �e�ۂ̔��ˊԊu
    bool Shot;

    private float nextFireTime = 0f;

    private void Start()
    {
        
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
        
        if (direction != Vector2.zero && Time.time > nextFireTime && _playerMove.IsRideZerima)
        {
            nextFireTime = Time.time+fireRate;
            Shoot(direction);
        }
    }

    void Shoot(Vector2 direction)
    {
        // �e�ۂ𐶐�
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        // �e�ۂ̕�����ݒ�
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * bulletSpeed;
    }
}

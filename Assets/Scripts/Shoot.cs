using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]private GameObject _bulletPrefab;

    [SerializeField]private float _bulletSpeed;

    private bool _fireContinuosly;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_fireContinuosly)
        {
            FireBullet();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D _rigidbody = bullet.GetComponent<Rigidbody2D>();
        _rigidbody.linearVelocity = _bulletSpeed * transform.up;
        Debug.Log("Fired");
    }
    
    
    private void Onfire(InputValue inputValue)
    {
        _fireContinuosly = inputValue.isPressed;
    }
    
    void Fire()
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * _bulletSpeed;
    }
}

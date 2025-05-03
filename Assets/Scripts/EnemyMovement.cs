using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private float _speed;

    [SerializeField]private float _rotationSpeed;

    private Rigidbody2D _rb;

    private EnemyDetect _playerAwarenessController;

    private Vector2 _targetDirection;
    
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<EnemyDetect>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsPlayer();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer) //eger oyuncu yakinsa
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer; // bize dogru donsun
        }
        else
        {
            _targetDirection = Vector2.zero; //yoksa sabir kalsin 
        }
    }

    private void RotateTowardsPlayer()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation =
            Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        _rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rb.linearVelocity = Vector2.zero;
        }
        else
        {
            _rb.linearVelocity = transform.up * _speed;
        }
    }
}

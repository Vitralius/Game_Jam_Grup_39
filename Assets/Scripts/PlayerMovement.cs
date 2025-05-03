using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private float targetRotation;
    [SerializeField] private float _rotationSpeed;
    
    
    private void Awake()
    {
        //rigidbody componentini bulmasi icin
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        //hizlanmasini girdi ve hiz degiskeniyle carpiyoruz
        _rb.linearVelocity = _moveInput * _moveSpeed;
        RotateInDirection();
    }

    public void Move (InputAction.CallbackContext context)
    {
        //klavyeden gelen girdinin yonunu alip kullaniyoruz 
        _moveInput = context.ReadValue<Vector2>();
    }

    private void RotateInDirection()
    {
        if (_moveInput != Vector2.zero) // eger hareket halindeysek
        {   //Quaternion rotasyon icin kullaniliyor. hedef yonu gosterip hangi yone bakmasini soyluyoruz
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _moveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, 
                targetRotation, _rotationSpeed * Time.deltaTime);

            _rb.MoveRotation(rotation);
        }
    }

}

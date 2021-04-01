using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 1;
    [SerializeField]
    private float _rotationSensivity = 1;

    private Rigidbody _playerRigidbody;

    private float _horizontalInput;
    private float _verticalInput;
    private float _mouseX;
    private float _mouseY;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetHorizontalInput();
        GetVerticalInput();
        GetMouseInput();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        _playerRigidbody.velocity = new Vector3(_horizontalInput * _speed, _playerRigidbody.velocity.y, _verticalInput * _speed);
    }

    private void Rotate()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;

        playerRotation.x -= _mouseY * _rotationSensivity;
        playerRotation.y += _mouseX * _rotationSensivity;
        playerRotation.z = 0;



        _playerRigidbody.rotation = Quaternion.Euler(playerRotation);
    }

    private void GetHorizontalInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void GetVerticalInput()
    {
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void GetMouseInput()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
    }
}

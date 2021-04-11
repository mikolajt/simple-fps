 using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 1;
    [SerializeField]
    private float _rotationSensivity = 1;

    private Rigidbody _playerRigidbody;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _horizontalVelocity;
    private Vector3 _verticalVelocity;
    private float _mouseX;
    private float _mouseY;
    private Vector3 _playerRotation;

    private Animator _assaultRifleAnimator;
    private Animator _handgunAnimator;
    private Animator _granadeThrowerAnimator;

    private int _moveSpeedHash = Animator.StringToHash("MoveSpeed");


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        _handgunAnimator = transform.GetChild(0).GetComponent<Animator>();
        _assaultRifleAnimator = transform.GetChild(1).GetComponent<Animator>();
        _granadeThrowerAnimator = transform.GetChild(2).GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        GetHorizontalInput();
        GetVerticalInput();
        GetMouseInput();

        Move();
        Rotate();
    }

    private void Move()
    {
        _horizontalVelocity = transform.right * _speed * _horizontalInput;
        _verticalVelocity = transform.forward * _speed * _verticalInput;

        _playerRigidbody.velocity = _verticalVelocity + _horizontalVelocity;

        _handgunAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
        _assaultRifleAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
        _granadeThrowerAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
    }

    private void Rotate()
    {
        _playerRotation = transform.rotation.eulerAngles;

        _playerRotation.x -= _mouseY * _rotationSensivity;
        _playerRotation.y += _mouseX * _rotationSensivity;
        _playerRotation.z = 0;

        if (_playerRotation.x > 90 && _playerRotation.x < 180)
        {
            _playerRotation.x = 90;
        }
        else if(_playerRotation.x > 180 && _playerRotation.x < 270)
        {
            _playerRotation.x = 270;
        }

        _playerRigidbody.rotation = Quaternion.Euler(_playerRotation);
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

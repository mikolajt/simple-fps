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

    private Animator _assasultRifleAnimator;
    private Animator _handgunAnimator;

    private int _moveSpeedHash = Animator.StringToHash("MoveSpeed");


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        _handgunAnimator = transform.GetChild(0).GetComponent<Animator>();
        _assasultRifleAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {
        GetHorizontalInput();
        GetVerticalInput();
        GetMouseInput();

        Move();
        Rotate();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Move()
    {
        _horizontalVelocity = transform.right * _speed * _horizontalInput;
        _verticalVelocity = transform.forward * _speed * _verticalInput;

        _playerRigidbody.velocity = _verticalVelocity + _horizontalVelocity;

        _handgunAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
        _assasultRifleAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
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

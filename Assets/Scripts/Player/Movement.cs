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
    private Vector3 _actualRotation;
    private Vector3 _playerRotation;

    private Animator _assaultRifleAnimator;
    private Animator _handgunAnimator;
    private Animator _granadeThrowerAnimator;

    private int _moveSpeedHash = Animator.StringToHash("MoveSpeed");

    private float _speedBoost = 1f;
    private float _speedBoostTime = 0f;

    private AudioSource _audioSource;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

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

        CheckSpeedBoostTime();
    }

    private void LateUpdate()
    {
        Rotate();
    }

    private void Move()
    {
        _horizontalVelocity = transform.right * _speed * _horizontalInput * _speedBoost;
        _verticalVelocity = transform.forward * _speed * _verticalInput * _speedBoost;

        _playerRigidbody.velocity = _verticalVelocity + _horizontalVelocity;

        _handgunAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
        _assaultRifleAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);
        _granadeThrowerAnimator.SetFloat(_moveSpeedHash, _horizontalInput * _speed + _verticalInput * _speed);

        if (!_audioSource.isPlaying && _playerRigidbody.velocity != Vector3.zero)
        {
            _audioSource.Play();
        }
        else if (_audioSource.isPlaying && _playerRigidbody.velocity == Vector3.zero)
        {
            _audioSource.Pause();
        }
    }

    private void Rotate()
    {
        _actualRotation = transform.rotation.eulerAngles;

        _playerRotation.x = Mathf.Lerp(_playerRotation.x, -_mouseY, _rotationSensivity * Time.deltaTime);
        _playerRotation.y = Mathf.Lerp(_playerRotation.y, _mouseX, _rotationSensivity * Time.deltaTime);
        _playerRotation.z = transform.eulerAngles.z;

        _actualRotation += _playerRotation;

        if (!(_actualRotation.x > 75 && _actualRotation.x < 285))
        {
           transform.Rotate(_playerRotation.x, _playerRotation.y, -_playerRotation.z);
        } 
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

    public void SetSpeedBoost(float boost, float time)
    {
        _speedBoost = boost;
        _speedBoostTime = time;
    }

    private void CheckSpeedBoostTime()
    {
        _speedBoostTime -= Time.deltaTime;
        if(_speedBoostTime <= 0)
        {
            _speedBoost = 1f;
        }
    }
}

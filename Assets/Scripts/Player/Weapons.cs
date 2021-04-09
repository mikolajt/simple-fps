using UnityEngine;

public class Weapons : MonoBehaviour
{
    private int _activeWeapon = 0;
    [SerializeField]
    private GameObject[] _weapons;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _grenadePrefab;

    private Handgun _handgun;
    private AssaultRifle _assaultRifle;
    private GrenadeThrower _grenadeThrower;
    [SerializeField]
    private float _handgunDamage = 30f;
    [SerializeField]
    private float _assaultRifleDamage = 20f;
    [SerializeField]
    private float _grenadeDamage = 50f;
    [SerializeField]
    private float _grenadeThrowForce = 10f;

    [SerializeField]
    private float _assaultRifleShootingFrequency = 0.1f;
    [SerializeField]
    private float _grenadeThrowingFrequency = 2f;

    private Animator _assasultRifleAnimator;
    private Animator _handgunAnimator;
    private Animator _grenadeAnimator;

    void Start()
    {
        _handgunAnimator = transform.GetChild(0).GetComponent<Animator>();
        _assasultRifleAnimator = transform.GetChild(1).GetComponent<Animator>();
        _grenadeAnimator = transform.GetChild(2).GetComponent<Animator>();

        _handgun = new Handgun(_handgunDamage, _handgunAnimator);
        _assaultRifle = new AssaultRifle(_assaultRifleDamage, _assasultRifleAnimator);
        _grenadeThrower = new GrenadeThrower(_grenadeDamage, _grenadeThrowForce, _grenadeAnimator);

        _weapons[0].SetActive(true);
        _weapons[1].SetActive(false);
        _weapons[2].SetActive(false);
    }

    void Update()
    {
        Shoot();
        SwapWeapon();
    }

    private void Shoot()
    {
        if(_activeWeapon == 0)
        {
            _handgun.Shoot(_bulletPrefab, _weapons[0].transform.GetChild(0).gameObject, 0f);
        }
        if(_activeWeapon == 1)
        {
            _assaultRifle.Shoot(_bulletPrefab, _weapons[1].transform.GetChild(0).gameObject, _assaultRifleShootingFrequency);
        }
        if(_activeWeapon == 2)
        {
            _grenadeThrower.Shoot(_grenadePrefab, _weapons[2].transform.GetChild(0).gameObject, _grenadeThrowingFrequency);
        }
    }

    private void SwapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(_activeWeapon != 0)
            {
                _weapons[0].SetActive(true);
                _weapons[1].SetActive(false);
                _weapons[2].SetActive(false);

                _activeWeapon = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(_activeWeapon != 1)
            {
                _weapons[0].SetActive(false);
                _weapons[1].SetActive(true);
                _weapons[2].SetActive(false);

                _activeWeapon = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (_activeWeapon != 2)
            {
                _weapons[0].SetActive(false);
                _weapons[1].SetActive(false);
                _weapons[2].SetActive(true);

                _activeWeapon = 2;
            }
        }
    }
}

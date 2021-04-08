using UnityEngine;

public class Weapons : MonoBehaviour
{
    private int _activeWeapon = 0;
    [SerializeField]
    private GameObject[] _weapons;
    [SerializeField]
    private GameObject _bulletPrefab;

    private Handgun _handgun;
    private AssaultRifle _assaultRifle;
    [SerializeField]
    private float _handgunDamage = 30f;
    [SerializeField]
    private float _assaultRifleDamage = 20f;

    [SerializeField]
    private float _assaultRifleShootingFrequency = 0.1f;

    private Animator _assasultRifleAnimator;
    private Animator _handgunAnimator;

    void Start()
    {
        _handgunAnimator = transform.GetChild(0).GetComponent<Animator>();
        _assasultRifleAnimator = transform.GetChild(1).GetComponent<Animator>();

        _handgun = new Handgun(_handgunDamage, _handgunAnimator);
        _assaultRifle = new AssaultRifle(_assaultRifleDamage, _assasultRifleAnimator);

        _weapons[0].SetActive(true);
        _weapons[1].SetActive(false);
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
    }

    private void SwapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(_activeWeapon != 0)
            {
                _weapons[0].SetActive(true);
                _weapons[1].SetActive(false);

                _activeWeapon = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(_activeWeapon != 1)
            {
                _weapons[0].SetActive(false);
                _weapons[1].SetActive(true);

                _activeWeapon = 1;
            }
        }
    }
}

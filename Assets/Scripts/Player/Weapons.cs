using UnityEngine;
using UnityEngine.UI;

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
    private int _handgunBulletAmount = 30;
    [SerializeField]
    private int _assaultRifleBulletAmount = 50;
    [SerializeField]
    private int _grenadeAmount = 5;

    [SerializeField]
    private float _assaultRifleShootingFrequency = 0.1f;
    [SerializeField]
    private float _grenadeThrowingFrequency = 2f;

    private Animator _assaultRifleAnimator;
    private Animator _handgunAnimator;
    private Animator _grenadeAnimator;

    [SerializeField]
    private GameObject _ammoUI;
    [SerializeField]
    private Sprite[] _weaponsImages; 

    void Start()
    {
        _handgunAnimator = transform.GetChild(0).GetComponent<Animator>();
        _assaultRifleAnimator = transform.GetChild(1).GetComponent<Animator>();
        _grenadeAnimator = transform.GetChild(2).GetComponent<Animator>();

        _handgun = new Handgun(_handgunDamage, _handgunBulletAmount, _handgunAnimator);
        _assaultRifle = new AssaultRifle(_assaultRifleDamage, _assaultRifleBulletAmount, _assaultRifleAnimator);
        _grenadeThrower = new GrenadeThrower(_grenadeDamage, _grenadeThrowForce, _grenadeAmount, _grenadeAnimator);

        _weapons[0].SetActive(true);
        _weapons[1].SetActive(false);
        _weapons[2].SetActive(false);
    }

    void Update()
    {
        Shoot();
        SwapWeapon();

        _handgun.CheckDamageBoostTime();
        _assaultRifle.CheckDamageBoostTime();
        _grenadeThrower.CheckDamageBoostTime();

        AmmunitionUI();
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

    private void AmmunitionUI()
    {
        if(_activeWeapon == 0)
        {
            _ammoUI.transform.GetChild(0).GetComponent<Text>().text = "Ammo: " + _handgun.GetAmmunition();
            _ammoUI.transform.GetChild(1).GetComponent<Image>().sprite = _weaponsImages[0];
        }
        if (_activeWeapon == 1)
        {
            _ammoUI.transform.GetChild(0).GetComponent<Text>().text = "Ammo: " + _assaultRifle.GetAmmunition();
            _ammoUI.transform.GetChild(1).GetComponent<Image>().sprite = _weaponsImages[1];
        }
        if (_activeWeapon == 2)
        {
            _ammoUI.transform.GetChild(0).GetComponent<Text>().text = "Ammo: " + _grenadeThrower.GetAmmunition();
            _ammoUI.transform.GetChild(1).GetComponent<Image>().sprite = _weaponsImages[2];
        }
    }

    public Gun GetWeapon(WeaponTypeEnum type)
    {
        if(type == WeaponTypeEnum.Handgun)
        {
            return _handgun;
        }
        else if(type == WeaponTypeEnum.AssaultRifle)
        {
            return _assaultRifle;
        }
        else if(type == WeaponTypeEnum.Grenade)
        {
            return _grenadeThrower;
        }
        else
        {
            return null;
        }
    }
}

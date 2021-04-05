using UnityEngine;

public class Weapons : MonoBehaviour
{
    private int _activeWeapon = 0;

    [SerializeField]
    private GameObject[] _weapons;
    [SerializeField]
    private GameObject _bulletPrefab;

    private Handgun _handgun = new Handgun();
    private AssaultRifle _assaultRifle = new AssaultRifle();

    [SerializeField]
    private float _assaultRifleShootingFrequency = 0.1f;

    void Start()
    {
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
            _handgun.Shoot(_bulletPrefab, 0f);
        }
        if(_activeWeapon == 1)
        {
            _assaultRifle.Shoot(_bulletPrefab, _assaultRifleShootingFrequency);
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

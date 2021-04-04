using UnityEngine;

public class Shooting : MonoBehaviour
{
    private int _activeWeapon = 0;

    [SerializeField]
    private GameObject[] _weapons;

    void Start()
    {
        _weapons[0].SetActive(true);
        _weapons[1].SetActive(false);
    }

    void Update()
    {
        SwapWeapon();
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

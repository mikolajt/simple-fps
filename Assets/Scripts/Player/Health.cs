using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100f;
    private float _actualHealth;

    public float _armor = 0f;
    private float _currentArmor;

    [SerializeField]
    private Slider _healthBar;
    [SerializeField]
    private Slider _armorBar;
    [SerializeField]
    private GameObject _armorUI;

    void Start()
    {
        _actualHealth = _maxHealth;
        _currentArmor = _armor;

        _healthBar.value = CalculateHealth();
        CheckIfArmorExists();
    }

    void Update()
    {
        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
        if (_actualHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private float CalculateHealth()
    {
        return _actualHealth / _maxHealth;
    }

    private float CalculateArmor()
    {
        return _currentArmor / _armor;
    }

    private void CheckIfArmorExists()
    {
        if(_armor <= 0)
        {
            _armorUI.SetActive(false);
        }
        else
        {
            _armorUI.SetActive(true);
        }
    }

    public void AddHealth(float health)
    {
        _actualHealth += health;
        if(_actualHealth > _maxHealth)
        {
            _actualHealth = _maxHealth;
        }
        _healthBar.value = CalculateHealth();
    }

    public void SubstractHealth(float health)
    {
        _actualHealth -= health;
        _healthBar.value = CalculateHealth();
    }

    public float GetArmor()
    {
        return _currentArmor;
    }

    public void SetArmor(float armor)
    {
        _armor = armor;
        _currentArmor = _armor;
        _armorBar.value = CalculateArmor();
        CheckIfArmorExists();
    }

    public void SubstractArmor(float armor)
    {
        _currentArmor -= armor;
        if(_currentArmor <= 0)
        {
            _currentArmor = 0f;
            _armor = 0f;
        }
        else
        {
            _armorBar.value = CalculateArmor();
        }
        CheckIfArmorExists();
    }
}

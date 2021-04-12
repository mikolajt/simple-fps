using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100f;
    private float _actualHealth;

    private float _armor = 0f;

    void Start()
    {
        _actualHealth = _maxHealth;
    }

    void Update()
    {
        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
        if (_actualHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(float health)
    {
        _actualHealth += health;
        if(_actualHealth > _maxHealth)
        {
            _actualHealth = _maxHealth;
        }
    }

    public void SubstractHealth(float health)
    {
        _actualHealth -= health;
    }

    public void SetArmor(float armor)
    {
        _armor = armor;
    }

    public float GetArmor()
    {
        return _armor;
    }
    public void SubstractArmor(float armor)
    {
        _armor -= armor;
        if(_armor < 0)
        {
            _armor = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100f;

    public float actualHealth;

    void Start()
    {
        actualHealth = _maxHealth;
    }

    void Update()
    {
        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
        Debug.Log(actualHealth);
        if (actualHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

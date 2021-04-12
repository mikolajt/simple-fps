using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _lifespan = 5f;
    private float _lifeTimer;

    private Rigidbody _bulletRigidbody;

    public float damage;

    void Start()
    {
        _lifeTimer = _lifespan;
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Flight();
        CheckLifeTime();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        if(other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 8)
        {
            if(other.gameObject.GetComponent<Health>().GetArmor() > 0)
            {
                other.gameObject.GetComponent<Health>().SubstractArmor(damage);
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<Health>().SubstractHealth(damage);
                Destroy(gameObject);
            }
        }
    }

    private void Flight()
    {
        _bulletRigidbody.velocity = transform.up * _speed;
    }

    private void CheckLifeTime()
    {
        _lifeTimer -= Time.deltaTime;
        if(_lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}


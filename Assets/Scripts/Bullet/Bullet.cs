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
            Debug.Log("Bum");
            Destroy(gameObject);
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


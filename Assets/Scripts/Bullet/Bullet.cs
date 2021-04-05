using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        BulletFlight();
    }

    private void BulletFlight()
    {
        transform.position += transform.forward * _speed;
    }
}

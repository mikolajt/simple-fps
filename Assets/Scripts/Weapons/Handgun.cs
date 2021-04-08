using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Gun
{
    public Handgun(float damage, Animator animator) : base(damage, animator)
    {
        
    }
    public override void Shoot(GameObject bulletPrefab, GameObject bulletSpawn, float shootingFrequency)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GenerateBulllet(bulletPrefab, bulletSpawn);

            _animator.SetTrigger(_shootHash);
        }
    }
}


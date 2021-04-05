using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Gun
{
    public override void Shoot(GameObject bulletPrefab, float shootingFrequency)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GenerateBulllet(bulletPrefab);
        }
    }
}


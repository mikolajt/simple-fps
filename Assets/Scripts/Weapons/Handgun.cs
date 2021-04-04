using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun
{
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Fire");
        }
    }
}


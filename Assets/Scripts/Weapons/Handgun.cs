using UnityEngine;

public class Handgun : Gun
{
    public Handgun(float damage, int ammunition, Animator animator) : base(damage, ammunition, animator)
    {
        Type = WeaponTypeEnum.Handgun;
    }
    public override void Shoot(GameObject bulletPrefab, GameObject bulletSpawn, float shootingFrequency)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _ammunition > 0)
        {
            GenerateBulllet(bulletPrefab, bulletSpawn);
            _ammunition--;

            _animator.SetTrigger(_shootHash);
        }
    }
}


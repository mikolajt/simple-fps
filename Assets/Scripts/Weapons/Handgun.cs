using UnityEngine;

public class Handgun : Gun
{
    public Handgun(float damage, int ammunition, Animator animator, AudioSource audioSource) : base(damage, ammunition, animator, audioSource)
    {
        Type = WeaponTypeEnum.Handgun;
    }
    public override void Shoot(GameObject bulletPrefab, GameObject bulletSpawn, float shootingFrequency)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _ammunition > 0)
        {
            GenerateBulllet(bulletPrefab, bulletSpawn);
            _ammunition--;

            _audioSource.Play();
            _animator.SetTrigger(_shootHash);
        }
    }
}


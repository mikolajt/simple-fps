using UnityEngine;

public class AssaultRifle : Gun
{
    private float _time;

    public AssaultRifle(float damage, int ammunition, Animator animator) : base(damage, ammunition, animator)
    {
        _time = 0f;

        Type = WeaponTypeEnum.AssaultRifle;
    }

    public override void Shoot(GameObject bulletPrefab, GameObject bulletSpawn, float shootingFrequency)
    {
        if (Input.GetKey(KeyCode.Mouse0) && _time <= 0 && _ammunition > 0)
        {
            GenerateBulllet(bulletPrefab, bulletSpawn);
            _ammunition--;

            _time = shootingFrequency;

            _animator.SetTrigger(_shootHash);
        }
        else if(Input.GetKey(KeyCode.Mouse0) && _time > 0 || !Input.GetKey(KeyCode.Mouse0) && _time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
}

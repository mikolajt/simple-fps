using UnityEngine;

public class AssaultRifle : Gun
{
    private float _time;

    public AssaultRifle(float damage, Animator animator) : base(damage, animator)
    {
        _time = 0f;
    }

    public override void Shoot(GameObject bulletPrefab, GameObject bulletSpawn, float shootingFrequency)
    {
        if (Input.GetKey(KeyCode.Mouse0) && _time <= 0)
        {
            GenerateBulllet(bulletPrefab, bulletSpawn);
            _time = shootingFrequency;

            _animator.SetTrigger(_shootHash);
        }
        else if(Input.GetKey(KeyCode.Mouse0) && _time > 0 || !Input.GetKey(KeyCode.Mouse0) && _time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
}

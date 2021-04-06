using UnityEngine;

public class AssaultRifle : Gun
{
    private float _time;

    public AssaultRifle(float damage) : base(damage)
    {
        _time = 0f;
    }

    public override void Shoot(GameObject bulletPrefab, GameObject weapon, float shootingFrequency)
    {
        if (Input.GetKey(KeyCode.Mouse0) && _time <= 0)
        {
            GenerateBulllet(bulletPrefab, weapon);
            _time = shootingFrequency;
        }
        else if(Input.GetKey(KeyCode.Mouse0) && _time > 0 || !Input.GetKey(KeyCode.Mouse0) && _time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
}

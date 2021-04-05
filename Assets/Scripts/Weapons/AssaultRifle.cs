using UnityEngine;

public class AssaultRifle : Gun
{
    private float _time = 0f;

    public override void Shoot(GameObject bulletPrefab, float shootingFrequency)
    {
        if (Input.GetKey(KeyCode.Mouse0) && _time <= 0)
        {
            GenerateBulllet(bulletPrefab);
            _time = shootingFrequency;
        }
        else if(Input.GetKey(KeyCode.Mouse0) && _time > 0 || !Input.GetKey(KeyCode.Mouse0) && _time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
}

using UnityEngine;

public class AssaultRifle
{
    private float _time = 0f;

    public void Shoot(float shootingFrequency)
    {
        if (Input.GetKey(KeyCode.Mouse0) && _time <= 0)
        {
            Debug.Log("Fire");
            _time = shootingFrequency;
        }
        else if(Input.GetKey(KeyCode.Mouse0) && _time > 0 || !Input.GetKey(KeyCode.Mouse0) && _time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
}

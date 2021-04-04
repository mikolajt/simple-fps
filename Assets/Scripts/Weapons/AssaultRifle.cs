using UnityEngine;

public class AssaultRifle
{
    public void Shoot(float shootingFrequency, float time = 0f)
    {
        if (Input.GetKey(KeyCode.Mouse0) && time <= 0)
        {
            Debug.Log("Fire");
            time = shootingFrequency;
        }
        else if(Input.GetKey(KeyCode.Mouse0) && time > 0 || !Input.GetKey(KeyCode.Mouse0) && time > 0)
        {
            time -= Time.deltaTime;
        }
    }
}

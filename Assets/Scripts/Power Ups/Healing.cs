using UnityEngine;

public class Healing : PowerUp
{

    protected override void CreatePowerUp(Collider powerUpCollider)
    {
        if(powerUpCollider.gameObject.layer == 8)
        {
            powerUpCollider.gameObject.GetComponent<Health>().AddHealth(_amount);

            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Armor : PowerUp
{

    protected override void CreatePowerUp(Collider powerUpCollider)
    {
        if(powerUpCollider.gameObject.layer == 8)
        {
            powerUpCollider.gameObject.GetComponent<Health>().SetArmor(_amount);

            Destroy(gameObject);
        }
    }
}

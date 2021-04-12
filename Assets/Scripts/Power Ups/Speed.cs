using UnityEngine;

public class Speed : PowerUp
{
    protected override void CreatePowerUp(Collider powerUpCollider)
    {
        if(powerUpCollider.gameObject.layer == 8)
        {
            powerUpCollider.gameObject.GetComponent<Movement>().SetSpeedBoost(_amount, _upgradeTime);

            Destroy(gameObject);
        }
    }
}

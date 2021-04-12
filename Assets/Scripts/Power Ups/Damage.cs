using UnityEngine;

public class Damage : PowerUp
{
    protected override void CreatePowerUp(Collider powerUpCollider)
    {
        if(powerUpCollider.gameObject.layer == 8)
        {
            powerUpCollider.gameObject.GetComponent<Weapons>().GetWeapon(WeaponTypeEnum.Handgun).DamageBoost(_amount, _upgradeTime);
            powerUpCollider.gameObject.GetComponent<Weapons>().GetWeapon(WeaponTypeEnum.AssaultRifle).DamageBoost(_amount, _upgradeTime);

            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Ammo : PowerUp
{
    [SerializeField]
    private WeaponTypeEnum _type;


    protected override void CreatePowerUp(Collider powerUpCollider)
    {
        powerUpCollider.gameObject.GetComponent<Weapons>().GetWeapon(_type).AddAmmunition((int)_amount);

        Destroy(gameObject);
    }

    public void SetType(WeaponTypeEnum type)
    {
        _type = type;
    }

}

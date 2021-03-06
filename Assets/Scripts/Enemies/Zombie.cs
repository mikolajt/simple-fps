using UnityEngine;

public class Zombie : Enemy
{
    protected override void Attack()
    {
        if (_isPlayerInSightRange && _isPlayerInAttackRange)
        {
            if (playerGameObject.GetComponent<Health>().GetArmor() > 0)
            {
                if (_damage > playerGameObject.GetComponent<Health>().GetArmor())
                {
                    float difference = _damage - playerGameObject.GetComponent<Health>().GetArmor();
                    playerGameObject.GetComponent<Health>().SubstractArmor(playerGameObject.GetComponent<Health>().GetArmor());
                    playerGameObject.GetComponent<Health>().SubstractHealth(difference);
                }
                else
                {
                    playerGameObject.GetComponent<Health>().SubstractArmor(_damage);
                }
            }
            else
            {
                playerGameObject.GetComponent<Health>().SubstractHealth(_damage);
            }
        }
    }

    protected override void SpawnAmmo(GameObject ammoPowerUp, Vector3 spawnPoint)
    {
        GameObject ammo = GameObject.Instantiate(ammoPowerUp, spawnPoint, Quaternion.identity);
        ammo.GetComponent<Ammo>().SetType(WeaponTypeEnum.Handgun);
    }
}

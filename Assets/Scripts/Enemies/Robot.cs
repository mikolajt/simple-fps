using UnityEngine;

public class Robot : Enemy
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _bulletSpawn;

    protected override void Attack()
    {
        GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, _bulletSpawn.transform.position, _bulletSpawn.transform.rotation);

        bulletObject.GetComponent<Bullet>().damage = _damage;
    }

    protected override void SpawnAmmo(GameObject ammoPowerUp, Vector3 spawnPoint)
    {
        GameObject ammo = GameObject.Instantiate(ammoPowerUp, spawnPoint, Quaternion.identity);
        ammo.GetComponent<Ammo>().SetType(WeaponTypeEnum.AssaultRifle);
    }
}

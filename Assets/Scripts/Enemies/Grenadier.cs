using UnityEngine;

public class Grenadier : Enemy
{
    [SerializeField]
    private GameObject _grenadePrefab;
    [SerializeField]
    private GameObject _grenadeSpawn;
    [SerializeField]
    private float _throwForce = 20f;

    protected override void Attack()
    {
        GameObject grenadeObject = GameObject.Instantiate(_grenadePrefab, _grenadeSpawn.transform.position, _grenadeSpawn.transform.rotation);
        Rigidbody grenadeRigidbody = grenadeObject.GetComponent<Rigidbody>();

        if (grenadeObject.GetComponent<Grenade>())
        {
            grenadeObject.GetComponent<Grenade>().damage = _damage;
            grenadeObject.GetComponent<Grenade>().isFromGrenadier = true;
        }

        grenadeRigidbody.AddForce(grenadeObject.transform.forward * _throwForce + grenadeObject.transform.up * _throwForce / 2, ForceMode.VelocityChange);
    }

    protected override void SpawnAmmo(GameObject ammoPowerUp, Vector3 spawnPoint)
    {
        GameObject ammo = GameObject.Instantiate(ammoPowerUp, spawnPoint, Quaternion.identity);
        ammo.GetComponent<Ammo>().SetType(WeaponTypeEnum.Grenade);
    }
}

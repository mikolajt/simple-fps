using UnityEngine;

public abstract class Gun 
{
    private float _damage;

    protected Animator _animator;
    protected int _shootHash;

    public Gun(float damage, Animator animator)
    {
        _damage = damage;

        _animator = animator;
        _shootHash = Animator.StringToHash("Shoot");
    }

    public abstract void Shoot(GameObject bulletPrefab, GameObject bulletSpawn, float shootingFrequency);


    protected void GenerateBulllet(GameObject bulletPrefab, GameObject bulletSpawn)
    {
        GameObject bulletObject = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

        bulletObject.GetComponent<Bullet>().damage = _damage;
    }
}

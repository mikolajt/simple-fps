using UnityEngine;

public abstract class Gun 
{
    protected float _damage;

    protected Animator _animator;
    protected int _shootHash;

    public Gun(float damage, Animator animator)
    {
        _damage = damage;

        _animator = animator;
        _shootHash = Animator.StringToHash("Shoot");
    }

    public abstract void Shoot(GameObject projectilePrefab, GameObject projectileSpawn, float shootingFrequency);


    protected void GenerateBulllet(GameObject projectilePrefab, GameObject projectileSpawn)
    {
        GameObject projectileObject = GameObject.Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);

        if (projectileObject.GetComponent<Bullet>())
        {
            projectileObject.GetComponent<Bullet>().damage = _damage;
        }
    }
}

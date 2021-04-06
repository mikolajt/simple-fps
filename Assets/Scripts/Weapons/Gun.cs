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

    public abstract void Shoot(GameObject bulletPrefab, GameObject weapon, float shootingFrequency);


    protected void GenerateBulllet(GameObject bulletPrefab, GameObject weapon)
    {
        GameObject bulletObject = GameObject.Instantiate(bulletPrefab);

        bulletObject.transform.position = weapon.transform.position + weapon.transform.forward;
        bulletObject.transform.eulerAngles = new Vector3 (weapon.transform.eulerAngles.x + 90, weapon.transform.eulerAngles.y, weapon.transform.eulerAngles.z);

        bulletObject.GetComponent<Bullet>().damage = _damage;
    }
}

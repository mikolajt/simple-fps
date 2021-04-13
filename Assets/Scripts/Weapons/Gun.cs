using UnityEngine;

public abstract class Gun 
{
    protected float _damage;
    protected int _ammunition;

    protected Animator _animator;
    protected int _shootHash;

    protected AudioSource _audioSource;

    private float _damageBoost = 1f;
    private float _damageBoostTime = 0f;

    public WeaponTypeEnum Type { get; protected set; }

    public Gun(float damage, int ammunition, Animator animator, AudioSource audioSource)
    {
        _damage = damage;
        _ammunition = ammunition;

        _animator = animator;
        _shootHash = Animator.StringToHash("Shoot");

        _audioSource = audioSource;
    }

    public abstract void Shoot(GameObject projectilePrefab, GameObject projectileSpawn, float shootingFrequency);


    protected void GenerateBulllet(GameObject projectilePrefab, GameObject projectileSpawn)
    {
        GameObject projectileObject = GameObject.Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);

        if (projectileObject.GetComponent<Bullet>())
        {
            projectileObject.GetComponent<Bullet>().damage = _damage * _damageBoost;
        }
    }

    public void AddAmmunition(int newAmmo)
    {
        _ammunition += newAmmo;
    }

    public float GetAmmunition()
    {
        return _ammunition;
    }

    public void DamageBoost(float boost, float time)
    {
        _damageBoost = boost;
        _damageBoostTime = time;
    }

    public void CheckDamageBoostTime()
    {
        _damageBoostTime -= Time.deltaTime;
        if (_damageBoostTime <= 0)
        {
            _damageBoost = 1f;
        }
    }
}

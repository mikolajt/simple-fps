using UnityEngine;
public class GrenadeThrower : Gun
{
    private float _throwForce;
    private float _time;

    public GrenadeThrower(float damage, float throwForce, int ammunition, Animator animator, AudioSource audioSource) : base(damage, ammunition, animator, audioSource)
    {
        _throwForce = throwForce;
        _time = 0f;

        Type = WeaponTypeEnum.Grenade;
    }
    public override void Shoot(GameObject grenadePrefab, GameObject grenadeSpawn, float shootingFrequency)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _time <= 0 && _ammunition > 0)
        {
            _time = shootingFrequency;

            ThrowGrenade(grenadePrefab, grenadeSpawn);
            _ammunition--;

            _audioSource.Play();
            _animator.SetTrigger(_shootHash);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && _time > 0 || !Input.GetKeyDown(KeyCode.Mouse0) && _time > 0)
        {
            _time -= Time.deltaTime;
        }
    }

    public void ThrowGrenade(GameObject grenadePrefab, GameObject grenadeSpawn)
    {
        GameObject grenadeObject = GameObject.Instantiate(grenadePrefab, grenadeSpawn.transform.position, grenadeSpawn.transform.rotation);
        Rigidbody grenadeRigidbody = grenadeObject.GetComponent<Rigidbody>();

        if (grenadeObject.GetComponent<Grenade>())
        {
            grenadeObject.GetComponent<Grenade>().damage = _damage;
        }

        grenadeRigidbody.velocity = (grenadeObject.transform.forward * _throwForce + grenadeObject.transform.up * _throwForce / 2);

    }
}

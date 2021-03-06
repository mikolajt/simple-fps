using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float _delayExplosion = 3f;
    private float _explosionCountdown;

    [SerializeField]
    private float _explosionRadius = 5f;
    public float damage;

    public bool isFromGrenadier = false;

    [SerializeField]
    private GameObject _explosionEffect;

    void Start()
    {

        _explosionCountdown = _delayExplosion;
    }
    void Update()
    {
        DecreaseCountdown();

        if(_explosionCountdown <= 0f)
        {

            Explode();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

    private void DecreaseCountdown()
    {
        _explosionCountdown -= Time.deltaTime;
    }

    private void Explode()
    {
        GameObject.Instantiate(_explosionEffect, transform.position, transform.rotation);

        Collider[] objectsAffectedByExoplosion = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach(Collider collider in objectsAffectedByExoplosion)
        {
            if ((collider.gameObject.layer == 7 || collider.gameObject.layer == 9) && isFromGrenadier != true)
            {
                collider.GetComponent<Enemy>().health -= damage;
            }
            if (collider.gameObject.layer == 8)
            {
                if (collider.gameObject.GetComponent<Health>().GetArmor() > 0)
                {
                    if (damage > collider.gameObject.GetComponent<Health>().GetArmor())
                    {
                        float difference = damage - collider.gameObject.GetComponent<Health>().GetArmor();
                        collider.gameObject.GetComponent<Health>().SubstractArmor(collider.gameObject.GetComponent<Health>().GetArmor());
                        collider.gameObject.GetComponent<Health>().SubstractHealth(difference);
                    }
                    else
                    {
                        collider.gameObject.GetComponent<Health>().SubstractArmor(damage);
                    }
                }
                else
                {
                    collider.gameObject.GetComponent<Health>().SubstractHealth(damage);
                }
            }
        }
        Destroy(gameObject);
    }
}

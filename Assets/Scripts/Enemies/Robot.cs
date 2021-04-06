using UnityEngine;

public class Robot : Enemy
{
    [SerializeField]
    private GameObject _bulletPrefab;

    protected override void Attack()
    {
        GameObject bulletObject = GameObject.Instantiate(_bulletPrefab);

        bulletObject.transform.position = transform.position + transform.forward;
        bulletObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);

        bulletObject.GetComponent<Bullet>().damage = _damage;
    }
}

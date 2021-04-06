using UnityEngine;

public abstract class Gun 
{
    public abstract void Shoot(GameObject bulletPrefab, GameObject weapon, float shootingFrequency);


    protected void GenerateBulllet(GameObject bulletPrefab, GameObject weapon)
    {
        GameObject bulletObject = GameObject.Instantiate(bulletPrefab);
        bulletObject.transform.position = weapon.transform.position + weapon.transform.forward;

        bulletObject.transform.eulerAngles = new Vector3 (weapon.transform.eulerAngles.x + 90, weapon.transform.eulerAngles.y, weapon.transform.eulerAngles.z);
    }
}

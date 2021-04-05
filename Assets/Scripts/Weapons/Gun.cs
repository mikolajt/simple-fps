using UnityEngine;

public abstract class Gun 
{
    public virtual void Shoot(GameObject bulletPrefab, float shootingFrequency)
    {

    }

    protected void GenerateBulllet(GameObject bulletPrefab)
    {
        GameObject bulletObject = GameObject.Instantiate(bulletPrefab);
        bulletObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward;

        bulletObject.transform.eulerAngles = new Vector3 (Camera.main.transform.eulerAngles.x + 90, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
    }
}

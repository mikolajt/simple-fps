using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private bool _isAmmo;

    void Update()
    {
        if (_isAmmo)
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        }
    }
}

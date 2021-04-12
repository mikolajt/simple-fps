using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected float _amount;
    [SerializeField]
    protected float _lifetime;
    [SerializeField]
    protected float _upgradeTime;

    private float _timeLeft;

    private void Start()
    {
        _timeLeft = _lifetime;
    }

    private void Update()
    {
        if(_timeLeft <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _timeLeft -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            CreatePowerUp(other);
        }
    }

    protected abstract void CreatePowerUp(Collider powerUpCollider);
    }


public class Zombie : Enemy
{
    protected override void Attack()
    {
        if (_isPlayerInSightRange && _isPlayerInAttackRange)
        {
            playerGameObject.GetComponent<Health>().actualHealth -= _damage;
        }
    }
}

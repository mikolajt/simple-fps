public class Zombie : Enemy
{
    protected override void Attack()
    {
        _playerGameObject.GetComponent<Health>().actualHealth -= _damage;
    }
}

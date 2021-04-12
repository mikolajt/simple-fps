using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private float _timeBetweenSpawns = 5f;
    private float _expiredTime;

    [SerializeField]
    private GameObject[] _spawnSpots;
    [SerializeField]
    private GameObject[] _objectPrefabs;
    
    [SerializeField]
    private GameObject _playerGameObject;

    void Start()
    {
        _expiredTime = 0f;
    }

    void Update()
    {
        if (_expiredTime <= 0)
        {
            SpawnObject();
            _expiredTime = _timeBetweenSpawns;
        }
        else
        {
            _expiredTime -= Time.deltaTime;
        }
    }

    private GameObject RandomGameObject(GameObject[] gameObjects)
    {
        int index = Random.Range(0, gameObjects.Length);
        return gameObjects[index];
    }

    private void SpawnObject()
    {
        GameObject gameObject = GameObject.Instantiate(RandomGameObject(_objectPrefabs), RandomGameObject(_spawnSpots).transform.position, Quaternion.identity);

        if (gameObject.GetComponent<Enemy>())
        {
            gameObject.GetComponent<Enemy>().playerGameObject = _playerGameObject;
        }
        if (gameObject.GetComponent<PowerUp>())
        {
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(-90, 0, 0);
        }
    }
}

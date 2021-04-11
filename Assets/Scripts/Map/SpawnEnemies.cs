using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private float _timeBetweenSpawns = 5f;
    private float _expiredTime;

    [SerializeField]
    private GameObject[] _spawnSpots;
    [SerializeField]
    private GameObject[] _enemiesPrefabs;
    [SerializeField]
    private GameObject _playerGameObject;

    void Start()
    {
        _expiredTime = _timeBetweenSpawns;
    }

    void Update()
    {
        if(_expiredTime <= 0)
        {
            Spawn();
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

    private void Spawn()
    {
        GameObject enemy = GameObject.Instantiate(RandomGameObject(_enemiesPrefabs), RandomGameObject(_spawnSpots).transform.position, Quaternion.identity);

        enemy.GetComponent<Enemy>().playerGameObject = _playerGameObject;
    }
}

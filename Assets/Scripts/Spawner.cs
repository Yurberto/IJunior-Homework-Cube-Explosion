using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Cube _prefabToSpawn;

    [SerializeField, Range(0, 2)] int _minSpawnCount = 2;
    [SerializeField, Range(3, 6)] int _maxSpawnCount = 6;

    [SerializeField, Range(0, 1)] float _scaleFactor = 0.5f;
    [SerializeField, Range(0, 1)] float _splitChanceFactor = 0.5f;

    public event Action<Cube> ObjectSpawned;

    private void Awake()
    {
        int startSpawnValue = 3;

        for (int i = 0; i < startSpawnValue; i++)
        {
            var newObject = Instantiate(_prefabToSpawn, transform.position, transform.rotation);
            newObject.Init(_prefabToSpawn.SplitChance, _prefabToSpawn.transform.localScale);
        }
    }

    public List<Cube> Spawn(Cube cube)
    {
        List<Cube> spawnedObjects = new();

        int spawnCount = UnityEngine.Random.Range(_minSpawnCount, _maxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            var newObject = Instantiate(_prefabToSpawn, cube.transform.position, cube.transform.rotation);

            float newSplitChance = cube.SplitChance * _splitChanceFactor;
            Vector3 newScale = cube.transform.localScale * _scaleFactor;

            newObject.Init(newSplitChance, newScale);
            spawnedObjects.Add(newObject);

            ObjectSpawned?.Invoke(newObject);
        }

        return spawnedObjects;
    }
}

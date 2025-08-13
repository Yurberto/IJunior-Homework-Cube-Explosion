using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] RaycastDetector _raycaster;
    [SerializeField] Splitable _prefabToSpawn;

    [SerializeField, Range(0, 2)] int _minSpawnCount = 2;
    [SerializeField, Range(3, 6)] int _maxSpawnCount = 6;

    [SerializeField, Range(0, 1)] float _scaleFactor = 0.5f;
    [SerializeField, Range(0, 1)] float _splitChanceFactor = 0.5f;

    public event Action<Splitable> ObjectSpawned;

    private void Awake()
    {
        int startSpawnValue = 3;

        for (int i = 0; i < startSpawnValue; i++)
        {
            var newObject = Instantiate(_prefabToSpawn, transform.position, transform.rotation);
            newObject.Init(_prefabToSpawn.SplitChance, _prefabToSpawn.transform.localScale);
        }
    }

    private void OnEnable()
    {
        _raycaster.CubeHitted += Handle;
    }

    private void OnDisable()
    {
        _raycaster.CubeHitted -= Handle;
    }

    private void Handle(RaycastHit hit)
    {
        var splitableObject = hit.collider.GetComponent<Splitable>();

        if (splitableObject != null)
            if (splitableObject.SplitChance >= UnityEngine.Random.value)
                Spawn(splitableObject);
    }

    private void Spawn(Splitable splitableObject)
    {
        int spawnCount = UnityEngine.Random.Range(_minSpawnCount, _maxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            var newObject = Instantiate(_prefabToSpawn, splitableObject.transform.position, splitableObject.transform.rotation);

            float newSplitChance = splitableObject.SplitChance * _splitChanceFactor;
            Vector3 newScale = splitableObject.transform.localScale * _scaleFactor;

            newObject.Init(newSplitChance, newScale);

            ObjectSpawned?.Invoke(newObject);
        }
    }
}

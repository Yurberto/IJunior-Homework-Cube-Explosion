using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] RaycastDetector _raycaster;
    [SerializeField] Splitable _prefabToSpawn;

    [SerializeField, Range(0, 2)] int _minSpawnCount = 2;
    [SerializeField, Range(3, 6)] int _maxSpawnCount = 6;

    [SerializeField, Range(0, 1)] float _scaleFactor = 0.5f;

    private void Awake()
    {
        int startSpawnValue = 3;

        for (int i = 0; i < startSpawnValue; i++)
        {
            Instantiate(_prefabToSpawn, transform.position, transform.rotation);
        }
    }

    private void OnEnable()
    {
        _raycaster.CubeHitted += Spawn;
    }

    private void OnDisable()
    {
        _raycaster.CubeHitted -= Spawn;
    }

    private void Spawn(RaycastHit hit)
    {
        int spawnCount = Random.Range(_minSpawnCount, _maxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            var newObject = Instantiate(_prefabToSpawn, hit.transform.position, hit.transform.rotation);
            newObject.transform.localScale = hit.transform.localScale * _scaleFactor;
        }
    }
}

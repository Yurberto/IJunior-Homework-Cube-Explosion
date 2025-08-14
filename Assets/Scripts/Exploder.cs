using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField, Space(20)] private ParticleSystem _effect;

    [SerializeField, Range(0, 100)] private float _explosionRadius = 30f;
    [SerializeField, Range(0, 5000)] private float _explosionForce = 1000f;

    private void OnEnable()
    {
        _spawner.explodableObjectsSpawned += Explode;
    }

    private void OnDisable()
    {
        _spawner.explodableObjectsSpawned -= Explode;
    }

    private void Explode(List<Rigidbody> justSpawnedObjects)
    {
        Vector3 effectPosition = justSpawnedObjects[justSpawnedObjects.Count - 1].position;

        foreach (Rigidbody explodableObject in justSpawnedObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, effectPosition, _explosionRadius);
        }

        if (_effect != null)
            Instantiate(_effect, effectPosition, Quaternion.identity);
    }
}

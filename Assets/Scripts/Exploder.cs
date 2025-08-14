using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField, Space(20)] private ParticleSystem _effect;

    [SerializeField, Range(0, 100)] private float _explosionRadius = 30f;
    [SerializeField, Range(0, 5000)] private float _explosionForce = 1000f;

    public void Explode(List<Cube> justSpawnedObjects)
    {
        Vector3 explodePosition = justSpawnedObjects[justSpawnedObjects.Count - 1].transform.position;

        foreach (Cube explodableObject in justSpawnedObjects)
        {
            explodableObject.Rigidbody.AddExplosionForce(_explosionForce, explodePosition, _explosionRadius);
        }

        if (_effect != null)
        {
            SpawnTimedEffect(explodePosition);
        }
    }

    private void SpawnTimedEffect(Vector3 positionToSpawn)
    {
        ParticleSystem effectInstance = Instantiate(_effect, positionToSpawn, Quaternion.identity);

        var main = effectInstance.main;
        float totalDuration = main.duration + main.startLifetime.constantMax;

        Destroy(effectInstance.gameObject, totalDuration);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Exploder : MonoBehaviour
{
    [SerializeField, Space(20)] private ParticleSystem _effect;

    [SerializeField, Range(0, 100)] private float _explosionRadius = 30f;
    [SerializeField, Range(0, 5000)] private float _explosionForce = 1000f;

    public void Explode(Cube cube)
    {
        Vector3 explodePosition = cube.Rigidbody.position;

        float explosionFactor = GetExplosionFactor(cube);
        float explosionForce = _explosionForce * explosionFactor;
        float explosionRadius = _explosionRadius * explosionFactor;

        foreach (Rigidbody explodableObject in GetExplodableObjects(explodePosition, explosionRadius))
        {
            explodableObject.AddExplosionForce(explosionForce, explodePosition, explosionRadius);
        }

        if (_effect != null)
        {
            SpawnTimedEffect(explodePosition);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 explodePosition, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(explodePosition, explosionRadius);

        List<Rigidbody> explodableObjects = new();
        
        foreach (Collider hit in hits)
            if (hit.attachedRigidbody)
                explodableObjects.Add(hit.attachedRigidbody);

        return explodableObjects;
    }

    private float GetExplosionFactor(Cube cube)
    {
        var scale = cube.transform.localScale;
        float minScale = Mathf.Min(scale.x, scale.y, scale.z);

        return 1 / minScale;
    }

    private void SpawnTimedEffect(Vector3 positionToSpawn)
    {
        ParticleSystem effectInstance = Instantiate(_effect, positionToSpawn, Quaternion.identity);

        var main = effectInstance.main;
        float totalDuration = main.duration + main.startLifetime.constantMax;

        Destroy(effectInstance.gameObject, totalDuration);
    }
}

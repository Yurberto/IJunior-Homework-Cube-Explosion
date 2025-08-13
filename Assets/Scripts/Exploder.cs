using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private RaycastDetector _raycastDetector;
    [SerializeField, Space(20)] private ParticleSystem _effect;

    [SerializeField, Range(0, 100)] private float _explosionRadius = 30f;
    [SerializeField, Range(0, 5000)] private float _explosionForce = 1000f;

    private void OnEnable()
    {
        _raycastDetector.CubeHitted += Explode;
    }

    private void OnDisable()
    {
        _raycastDetector.CubeHitted -= Explode;
    }

    private void Explode(RaycastHit hit)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, hit.transform.position, _explosionRadius);
        }

        if (_effect != null)
            Instantiate(_effect, hit.transform.position, Quaternion.identity);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> objectsToExplode = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                objectsToExplode.Add(hit.attachedRigidbody);

        return objectsToExplode;
    }
}

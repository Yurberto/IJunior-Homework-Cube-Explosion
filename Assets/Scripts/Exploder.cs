using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private RaycastDetector _raycastDetector;

    private void OnEnable()
    {
        _raycastDetector.CubeHitted += Explode;
    }

    private void OnDisable()
    {
        _raycastDetector.CubeHitted -= Explode;
    }

    private void Explode(RaycastHit hitted)
    {

    }
}

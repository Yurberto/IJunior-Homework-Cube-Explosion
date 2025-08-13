using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private RaycastDetector _raycaster;

    private void OnEnable()
    {
        _raycaster.CubeHitted += DestroyObject;
    }

    private void OnDisable()
    {
        _raycaster.CubeHitted -= DestroyObject;
    }

    private void DestroyObject(RaycastHit objectToDestroy)
    {
        if (objectToDestroy.collider != null && objectToDestroy.collider.gameObject != null)
        {
            Destroy(objectToDestroy.collider.gameObject);
        }
    }
}

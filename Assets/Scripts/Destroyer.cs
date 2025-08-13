using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private RaycastDetector _raycaster;

    private void OnEnable()
    {
    }

    private void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}

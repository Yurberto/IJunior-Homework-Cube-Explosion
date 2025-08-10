using UnityEngine;

public class ExplodableCube : MonoBehaviour
{
    [SerializeField] private GameObject _clone;
    [SerializeField] private int _cloneQuantity;

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
        CreateClones();
    }

    private void CreateClones()
    {
        for (int i = 0; i < _cloneQuantity; i++)
        {
            Instantiate(_clone, transform.position, transform.rotation);
        }
    }
}

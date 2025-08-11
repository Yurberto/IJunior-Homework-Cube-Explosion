using UnityEngine;

public class ParentSetter : MonoBehaviour
{
    [SerializeField] private Transform _parent;

    private void Awake()
    {
        transform.SetParent(_parent);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;

    private void OnEnable()
    {
        var renderer = GetComponent<MeshRenderer>();

        int randomIndex = Random.Range(0, _materials.Count);

        renderer.material = _materials[randomIndex];
    }
}

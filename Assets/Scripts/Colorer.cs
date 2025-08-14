using UnityEngine;

public class Colorer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.ObjectSpawned += SetRandomColor;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= SetRandomColor;
    }

    private void SetRandomColor(Cube objectToChangeColor)
    {
        var meshRenderer = objectToChangeColor.GetComponent<MeshRenderer>();

        if (meshRenderer == null)
            return;
        
        meshRenderer.material.color = Random.ColorHSV();
    }
}

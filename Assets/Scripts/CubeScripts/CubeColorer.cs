using UnityEngine;

public class CubeColorer : MonoBehaviour
{
    private void Start()
    {
        ChangeColorToRandom();
    }

    private void ChangeColorToRandom()
    {
        var meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}

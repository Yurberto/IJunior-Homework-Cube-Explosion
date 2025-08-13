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

    private void SetRandomColor(Splitable objectToChangeColor)
    {
        objectToChangeColor.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}

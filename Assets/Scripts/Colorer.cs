using UnityEngine;

public class Colorer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.ObjectSpawned += ChangeColor;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= ChangeColor;
    }

    private void ChangeColor(Splitable objectToChangeColor)
    {

    }
}

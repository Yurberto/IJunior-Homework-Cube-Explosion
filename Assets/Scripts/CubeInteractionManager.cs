using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class CubeInteractionManager : MonoBehaviour
{
    [SerializeField] private RaycastDetector _raycastDetector;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Destoyer _destoyer;

    private void OnEnable()
    {
        _raycastDetector.CubeHitted += Handle;
    }

    private void OnDisable()
    {
        _raycastDetector.CubeHitted -= Handle;
    }

    private void Handle(Cube cube)
    {
        if (cube == null)
            return;

        if (cube.SplitChance > Random.value)
            _exploder.Explode(_spawner.Spawn(cube));

        _destoyer.DestroyCube(cube);
    }
}

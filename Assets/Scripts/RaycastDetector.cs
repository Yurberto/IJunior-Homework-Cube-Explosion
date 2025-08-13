using UnityEngine;
using UnityEngine.Events;

public class RaycastDetector : MonoBehaviour
{
    [SerializeField] InputHandler _inputHandler;
    [SerializeField] Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    [SerializeField] public event UnityAction<RaycastHit> CubeHitted;

    private void OnEnable()
    {
        _inputHandler.MouseLeftClicked += SendRay;
    }

    private void OnDisable()
    {
        _inputHandler.MouseLeftClicked -= SendRay;
    }

    private void SendRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.TryGetComponent<Splitable>(out _))
            {
                CubeHitted?.Invoke(_hit);
            }
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    
    [SerializeField] private float _moveSpeed = 5;

    private void OnEnable()
    {
        _inputHandler.InputDirectionChanged += Move;
    }

    private void OnDisable()
    {
        _inputHandler.InputDirectionChanged -= Move;
    }

    private void Move(Vector3 inputPosition)
    {
        transform.position += inputPosition * _moveSpeed * Time.deltaTime;
    }
}

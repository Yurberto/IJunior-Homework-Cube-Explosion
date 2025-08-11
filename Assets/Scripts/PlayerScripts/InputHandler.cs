using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public event Action<Vector3> InputDirectionChanged;

    private void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(Horizontal), 0f, Input.GetAxisRaw(Vertical));
        
        if (inputDirection != Vector3.zero)
        {
            InputDirectionChanged?.Invoke(inputDirection);
        }
    }
}

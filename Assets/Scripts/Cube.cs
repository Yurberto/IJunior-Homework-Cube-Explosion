using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private Rigidbody _rigidbody;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(float splitChance, Vector3 scale)
    {
        _splitChance = Mathf.Clamp01(splitChance);

        if (scale.x > 0 && scale.y > 0 && scale.z > 0)
            transform.localScale = scale;
    }
}

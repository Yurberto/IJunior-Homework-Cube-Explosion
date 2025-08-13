using UnityEngine;

public class Splitable : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _splitChance = 1f; 

    public float SplitChance => _splitChance;

    public void Init(float splitChance)
    {
        _splitChance = splitChance;
    }
}

using UnityEngine;

public class Splitable : MonoBehaviour
{
    private float _splitChance = 1f;
    public float SplitChance => _splitChance;

    public void Init(float splitChance, Vector3 scale)
    {
        _splitChance = Mathf.Clamp01(splitChance);

        if (scale.x > 0 && scale.y > 0 && scale.z > 0)
            transform.localScale = scale;

        Debug.Log(SplitChance.ToString());
    }
}

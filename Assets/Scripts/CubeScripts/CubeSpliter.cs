using UnityEngine;

public class CubeSpliter : MonoBehaviour
{
    [SerializeField, Range(2, 10)] private int _minCopiesValue = 2;
    [SerializeField, Range(3, 20)] private int _maxCopiesValue = 6;

    private float _splitChance = 1f;

    private int _splitChanceDivider = 2;
    private int _scaleDivider = 2;

    private void OnMouseUpAsButton()
    {
        if (ShouldSplit())
        {
            Split();
        }
    }

    private void OnValidate()
    {
        if(_minCopiesValue >= _maxCopiesValue)
            _minCopiesValue = _maxCopiesValue - 1;
    }

    private void Split()
    {
        int copiesCount = Random.Range(_minCopiesValue, _maxCopiesValue);

        for (int i = 0; i < copiesCount; i++)
        {
            CreateModifiedCopy();
        }
    }

    private bool ShouldSplit()
    {
        return _splitChance > Random.value;
    }

    private void CreateModifiedCopy()
    {
        GameObject copy = Instantiate(gameObject, transform.position, transform.rotation);

        copy.transform.localScale = transform.localScale / _scaleDivider;

        if (copy.GetComponent<CubeSpliter>() != null)
        {
            copy.GetComponent<CubeSpliter>()._splitChance = _splitChance / _splitChanceDivider;
        }
    }
}

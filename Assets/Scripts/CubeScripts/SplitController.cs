using UnityEngine;

public class SplitController : MonoBehaviour
{
    private const float _splitChanceReductionFactor = 0.5f;

    [SerializeField] private SplitController _originalCube;
    [SerializeField] private int _cloneQuantity;

    private float _splitChace = 0.5f;
    private float _scaleFactor = 0.5f;

    public float SplitChace => _splitChace;

    private void OnEnable()
    {
        _splitChace = _originalCube.SplitChace * _splitChanceReductionFactor;
        Debug.Log(_splitChace);
    }

    private void OnMouseUpAsButton()
    {
        if (MustSplit())
            CreateClones();
    }

    private void CreateClones()
    {
        for (int i = 0; i < _cloneQuantity; i++)
        {
            var newCube = Instantiate(_originalCube, _originalCube.transform.position, _originalCube.transform.rotation);
            newCube.transform.localScale *= _scaleFactor;
        }
    }

    private bool MustSplit()
    {
        const int PersentValue = 100;

        return PersentValue * _splitChace > UnityEngine.Random.Range(0, PersentValue + 1);
    }
}

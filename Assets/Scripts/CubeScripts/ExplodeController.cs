using UnityEngine;

public class ExplodeController : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
    }
}

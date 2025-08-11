using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
    }
}

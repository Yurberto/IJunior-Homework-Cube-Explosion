using UnityEngine;

public class Destoyer : MonoBehaviour
{
    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}

using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        if (gameObject.CompareTag("Object")) Destroy(gameObject,lifetime);
    }
}
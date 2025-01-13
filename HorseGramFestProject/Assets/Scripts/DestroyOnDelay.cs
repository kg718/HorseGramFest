using UnityEngine;

public class DestroyOnDelay : MonoBehaviour
{
    [SerializeField] private float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}

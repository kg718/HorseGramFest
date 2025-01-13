using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    void FixedUpdate()
    {
        transform.position = target.position;
    }
}

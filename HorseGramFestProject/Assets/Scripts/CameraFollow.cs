using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] private Transform target;

    void FixedUpdate()
    {
        transform.position = target.position + new Vector3(offset.x, 0, offset.y);
    }
}

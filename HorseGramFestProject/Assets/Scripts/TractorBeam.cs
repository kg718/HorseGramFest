using TMPro;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField] private Transform generator;
    [SerializeField] private Transform target;
    [SerializeField] private float maxLength;
    [SerializeField] private float forceMultiplier;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        target.localPosition = new Vector3(0, 0, maxLength);
    }

    void Update()
    {
        RaycastHit _hit;
        Physics.Raycast(generator.position, transform.forward, out _hit, maxLength);
        if(_hit.collider == null)
        {
            SetLinePositions(target.position);
        }
        else if (_hit.collider.gameObject.tag == "Damage")
        {
            SetLinePositions(_hit.point);
        }
        else if(_hit.collider.gameObject.tag == "Player")
        {
            Vector3 _dir = generator.position - target.position;
            _dir = _dir.normalized;
            _hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(_dir.x * forceMultiplier, 0, _dir.z * forceMultiplier));
        }
    }

    private void SetLinePositions(Vector3 _secondPos)
    {
        line.SetPosition(0, generator.position);
        line.SetPosition(1, _secondPos);
    }
}

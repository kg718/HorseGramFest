using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform generator1;
    [SerializeField] private Transform generator2;

    [Space]
    [SerializeField] private bool hasCycles = true;
    private bool isLaserActive = true;
    [SerializeField] private float activationTime;
    [SerializeField] private float activationDelay;
    private float currentActivationTimer = 0f;

    private LineRenderer line;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, generator1.position);
        line.SetPosition(1, generator2.position);
    }

    void Update()
    {
        if (isLaserActive)
        {
            DetectShip();
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
        if(hasCycles)
        {
            currentActivationTimer += Time.deltaTime;
            if (isLaserActive && currentActivationTimer >= activationTime)
            {
                isLaserActive = false;
                currentActivationTimer = 0f;
            }
            else if(!isLaserActive && currentActivationTimer >= activationDelay)
            {
                isLaserActive = true;
                currentActivationTimer = 0f;
            }
        }
    }

    public void DetectShip()
    {
        RaycastHit _hit;
        Vector3 _dir = generator2.transform.position - generator1.transform.position;
        float _dist = Vector3.Distance(generator1.transform.position, generator2.transform.position);
        Physics.Raycast(generator1.position, _dir, out _hit, _dist);
        Debug.DrawRay(generator1.position, _dir, Color.green);
        if (_hit.collider.gameObject.tag == "Player")
        {
            _hit.collider.gameObject.GetComponent<PlayerDamage>().TakeDamage(25);
        }
    }
}

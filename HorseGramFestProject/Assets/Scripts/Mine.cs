using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float explosionDelay;
    [SerializeField] private GameObject particleEffect;
    private bool isPlayerInRadius = false;
    private PlayerDamage shipDamage;

    [Space]
    [SerializeField] private Color colourFlash;
    [SerializeField] private float flashFrequency;
    private Color defaultColour;
    private float currentFlashTimer = 0f;
    private bool isFlashing = false;
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        defaultColour = mesh.material.color;
    }

    void Update()
    {
        if(isFlashing)
        {
            currentFlashTimer += Time.deltaTime;
        }
        if(currentFlashTimer > flashFrequency)
        {
            currentFlashTimer = 0f;
            if (mesh.material.color == defaultColour)
            {
                mesh.material.color = colourFlash;
            }
            else
            {
                mesh.material.color = defaultColour;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isPlayerInRadius = true;
            shipDamage = other.GetComponent<PlayerDamage>();
            ActivateFlash();
            Invoke("Explode", explosionDelay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isPlayerInRadius = false;
        }
    }

    public void ActivateFlash()
    {
        isFlashing = true;
    }

    private void Explode()
    {
        Instantiate(particleEffect, transform.position, transform.rotation);
        if (isPlayerInRadius)
        {
            shipDamage.TakeDamage(25);
        }
        Destroy(gameObject, 0.1f);
    }
}

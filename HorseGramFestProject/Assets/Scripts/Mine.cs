using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float explosionDelay;
    [SerializeField] private GameObject particleEffect;
    private bool isPlayerInRadius = false;
    private PlayerDamage shipDamage;

    [Space]
    [SerializeField] private Color colourFlash;
    [SerializeField] private Color spriteColourFlash;
    [SerializeField] private float flashFrequency;
    private Color defaultColour;
    private Color defaultSpriteColour;
    private float currentFlashTimer = 0f;
    private bool isFlashing = false;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private AudioSource beepSFX;

    void Start()
    {
        //mesh = GetComponent<MeshRenderer>();
        defaultColour = mesh.material.color;
        defaultSpriteColour = sprite.color;
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
                sprite.color = spriteColourFlash;
                beepSFX.Play();
            }
            else
            {
                mesh.material.color = defaultColour;
                sprite.color = defaultSpriteColour;
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
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        if (isPlayerInRadius)
        {
            shipDamage.TakeDamage(25);
        }
        Destroy(gameObject, 0.1f);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int health;
    private Rigidbody rb;

    [SerializeField] private float invulnarabilityWindow;
    private float currentInvulnarabilityTimer = 0f;
    private bool isInvulnarable = false;
    [SerializeField] private GameObject deathExplosion;
    private Animator transitionAnimator;
    private GameObject gameOverPanel;

    [Space]
    [SerializeField] private Color colourFlash;
    [SerializeField] private float flashFrequency;
    private Color defaultColour;
    private float currentFlashTimer = 0f;
    private bool isFlashing = false;
    [SerializeField] private MeshRenderer shipMesh;
    [SerializeField] private MeshRenderer glassMesh;
    [SerializeField] private GameObject damageParticleFX;

    [Header("Sound")]
    [SerializeField] private AudioSource collisionSFX;
    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private AudioSource warningSFX;

    [Header("UI")]
    [SerializeField] private List<GameObject> damagePercentages = new List<GameObject>();
    private int currentPercent = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultColour = shipMesh.material.color;
        transitionAnimator = GameObject.Find("Canvas").transform.GetChild(6).gameObject.GetComponent<Animator>();
        gameOverPanel = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if(isInvulnarable)
        {
            currentInvulnarabilityTimer += Time.deltaTime;
            if(currentInvulnarabilityTimer >= invulnarabilityWindow)
            {
                isInvulnarable = false;
                isFlashing = false;
                shipMesh.material.color = defaultColour;
                currentInvulnarabilityTimer = 0f;
                currentFlashTimer = 0f;
            }
        }
        if (isFlashing)
        {
            currentFlashTimer += Time.deltaTime;
        }
        if (currentFlashTimer > flashFrequency)
        {
            currentFlashTimer = 0f;
            if (shipMesh.material.color == defaultColour)
            {
                shipMesh.material.color = colourFlash;
            }
            else
            {
                shipMesh.material.color = defaultColour;
            }
        }
        if(!shipMesh.enabled)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            foreach (ContactPoint _contact in collision.contacts)
            {
                Vector3 _velocity = new Vector3(_contact.normal.x * 10, 0, _contact.normal.z * 10);
                rb.AddForce(_velocity, ForceMode.Impulse);
                Instantiate(damageParticleFX, _contact.point, Quaternion.Euler(-_contact.normal));
            }
            if(shipMesh.enabled && !collisionSFX.isPlaying)
            {
                collisionSFX.pitch = Random.Range(0.9f, 1.1f);
                collisionSFX.Play();
            }
            TakeDamage(25);
        }
    }

    public void TakeDamage(int _damage)
    {
        if(!isInvulnarable)
        {
            health -= _damage;
            isInvulnarable = true;
            ActivateFlash();
            damagePercentages[currentPercent].SetActive(true);
            currentPercent++;
            if(health == 25)
            {
                warningSFX.Play();
            }
            if (health <= 0)
            {
                Instantiate(deathExplosion, transform.position, Quaternion.identity);
                deathSFX.Play();
                rb.velocity = Vector3.zero;
                shipMesh.enabled = false;
                glassMesh.enabled = false;
                Invoke("Transition", 0.8f);
            }
        }
    }

    public void ActivateFlash()
    {
        isFlashing = true;
        shipMesh.material.color = colourFlash;
    }

    public void Transition()
    {
        transitionAnimator.Play("TransitionPanel_In");
        Invoke("GameOver", 1.5f);
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

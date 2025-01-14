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
    //[SerializeField, Range(0, 255)] private int flashAlpha;
    [SerializeField] private Color colourFlash;
    [SerializeField] private float flashFrequency;
    private Color defaultColour;
    private float currentFlashTimer = 0f;
    private bool isFlashing = false;
    [SerializeField] private MeshRenderer shipMesh;
    [SerializeField] private MeshRenderer glassMesh;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultColour = shipMesh.material.color;
        transitionAnimator = GameObject.Find("Canvas").transform.GetChild(0).gameObject.GetComponent<Animator>();
        gameOverPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
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
            if (health <= 0)
            {
                Instantiate(deathExplosion, transform.position, Quaternion.identity);
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

    private void Transition()
    {
        transitionAnimator.Play("TransitionPanel_In");
        Invoke("GameOver", 1.5f);
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

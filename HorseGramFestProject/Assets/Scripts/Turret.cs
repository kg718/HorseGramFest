using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shotSpeed;

    [SerializeField] private float shotDelay;
    private float currentShotTimer = 0f;

    [SerializeField] private float soundRange;
    private bool playerInRange;
    private GameObject playerObject;
    [SerializeField] private AudioSource shotSFX;
    [SerializeField] private AudioSource chargeSFX;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerObject.transform.position) <= soundRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
        currentShotTimer += Time.deltaTime;
        if(currentShotTimer > shotDelay - 0.8f && !chargeSFX.isPlaying && playerInRange)
        {
            chargeSFX.Play();
        }
        if (currentShotTimer >= shotDelay)
        {
            Shoot();
            currentShotTimer = 0f;
        }
    }

    public void Shoot()
    {
        Rigidbody _projectileRb = Instantiate(projectile, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        _projectileRb.velocity = transform.forward * shotSpeed;
        if(playerInRange)
        {
            shotSFX.Play();
        }
    }

    
}

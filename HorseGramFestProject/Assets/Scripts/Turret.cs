using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shotSpeed;

    [SerializeField] private float shotDelay;
    private float currentShotTimer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        currentShotTimer += Time.deltaTime;
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
    }
}

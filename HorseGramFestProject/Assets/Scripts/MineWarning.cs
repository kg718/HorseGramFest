using UnityEngine;

public class MineWarning : MonoBehaviour
{
    [SerializeField] private GameObject mine;
    [SerializeField] private float spawnTime;
    private float currentSpawnTimer = 0f;

    void Update()
    {
        currentSpawnTimer += Time.deltaTime;
        if (currentSpawnTimer >= spawnTime)
        {
            Instantiate(mine, transform.position, transform.rotation);
            currentSpawnTimer = 0f;
            Destroy(gameObject, 0.1f);
        }
    }
}

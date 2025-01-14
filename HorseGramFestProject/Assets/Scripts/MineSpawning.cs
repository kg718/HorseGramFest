using System.Collections.Generic;
using UnityEngine;

public class MineSpawning : MonoBehaviour
{
    [SerializeField] private bool singleUse = true;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject mineWarning;
    private bool HasSpawned = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(singleUse && HasSpawned)
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            foreach(Transform _point in spawnPoints)
            {
                Instantiate(mineWarning, _point.position, Quaternion.Euler(90,0,0));
            }
            HasSpawned = true;
        }
    }
}

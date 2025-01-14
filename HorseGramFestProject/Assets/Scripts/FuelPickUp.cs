using UnityEngine;

public class FuelPickUp : MonoBehaviour
{
    [SerializeField] private float fuelAmount = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.AddFuel(fuelAmount);
                Destroy(gameObject);
            }
        }
    }
}
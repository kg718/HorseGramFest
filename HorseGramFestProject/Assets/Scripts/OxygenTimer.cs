using UnityEngine;

public class OxygenTimer : MonoBehaviour
{
    [SerializeField] private float maxOxygen = 100f;
    [SerializeField] private float oxygenDepletionRate = 5f;

    public float MaxOxygen => maxOxygen;
    public float CurrentOxygen => currentOxygen;


    private float currentOxygen;
    private bool isOutOfOxygen = false;
    public bool IsOutOfOxygen => isOutOfOxygen;


    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private BoosterAnimation boosterAnimation;

    private void Start()
    {
        currentOxygen = maxOxygen;
    }

    private void Update()
    {
        if (isOutOfOxygen) return;
        currentOxygen -= oxygenDepletionRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
       
        if (currentOxygen <= 0)
        {
            OutOfOxygen();
        }

        Debug.Log($"Oxygen: {currentOxygen}");
    }

    private void OutOfOxygen()
    {
        isOutOfOxygen = true;
        if (boosterAnimation != null)
        {
            boosterAnimation.StopAllThrusters();
        }
        Debug.Log("You are out of oxygen!");
        DisablePlayerMovement();
    }

    private void DisablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    public void AddOxygen(float oxygenAmount)
    {
        currentOxygen = Mathf.Clamp(currentOxygen + oxygenAmount, 0, maxOxygen);
        Debug.Log($"Oxygen added: {oxygenAmount}. Current Oxygen: {currentOxygen}");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private Slider fuelSlider;
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        if (playerMovement != null)
        {
            fuelSlider.maxValue = playerMovement.MaxFuel;
            fuelSlider.value = playerMovement.CurrentFuel;
        }
    }

    private void Update()
    {
        if (playerMovement != null)
        {
            fuelSlider.value = playerMovement.CurrentFuel;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    [SerializeField] private Slider oxygenSlider;
    [SerializeField] private OxygenTimer oxygenTimer;

    private void Start()
    {
        if (oxygenTimer != null)
        {
            oxygenSlider.maxValue = oxygenTimer.MaxOxygen;
            oxygenSlider.value = oxygenTimer.CurrentOxygen;
        }
    }

    private void Update()
    {
        if (oxygenTimer != null)
        {
            oxygenSlider.value = oxygenTimer.CurrentOxygen;
        }
    }
}

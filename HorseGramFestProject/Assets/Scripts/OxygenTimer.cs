using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTimer : MonoBehaviour
{
    [SerializeField] private float maxOxygen;
    [SerializeField] private float oxygenConsumptionRate;
    [SerializeField] private Slider oxygenSlider;
    [HideInInspector] public float currentOxygen;
    [SerializeField] private TextMeshProUGUI gameOverText;
    private Rigidbody rb;

    void Start()
    {
        currentOxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentOxygen -= oxygenConsumptionRate * Time.deltaTime;
        oxygenSlider.value = currentOxygen;

        if(currentOxygen <= 0)
        {
            rb.velocity = Vector3.zero;
            GetComponent<PlayerMovement>().currentFuel = 0;
            Invoke("Transition", 0.8f);
        }
        if (currentOxygen > maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
    }

    private void Transition()
    {
        gameObject.GetComponent<PlayerDamage>().Transition();
        gameOverText.text = "You ran out of Oxygen";
    }
}

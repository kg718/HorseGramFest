using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    MasterInput controls;

    [SerializeField] private float thrusterPower;
    [SerializeField] private float velocityCap;

    [Space]
    [SerializeField] private Transform thruster1;
    [SerializeField] private Transform thruster2;
    [SerializeField] private Transform thruster3;
    [SerializeField] private Transform thruster4;

    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private float fuelConsumptionRate = 5f;

    [SerializeField] private Slider fuelSlider;

    [HideInInspector] public float currentFuel;
     public float CurrentFuel => currentFuel;
    private Rigidbody rb;

    [SerializeField] private AudioSource thrusterSFX;

    private void Awake()
    {
        controls = new MasterInput();
        controls.Enable();
        currentFuel = maxFuel;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        int _randYRotation = Random.Range(0, 360); 
        transform.rotation = Quaternion.Euler(0, _randYRotation, 0);
        fuelSlider.maxValue = maxFuel;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }

    private void Update()
    {
        fuelSlider.value = CurrentFuel;
        Vector3 _velocity = Vector3.zero;

        if (currentFuel <= 0)
        {
            return;
        }

        if (controls.Player.Booster1.IsInProgress() && controls.Player.Booster2.IsInProgress() && controls.Player.Booster3.IsInProgress() && controls.Player.Booster4.IsInProgress())
        {
            rb.angularVelocity = Vector3.zero;
        }

        int activeEngines = 0;

        if (controls.Player.Booster1.IsInProgress() && controls.Player.Booster3.IsInProgress())
        {
            activeEngines++;
            activeEngines++;
        }
        else if (controls.Player.Booster1.IsInProgress())
        {
            _velocity += new Vector3(thruster1.forward.x, 0, thruster1.forward.z);
            rb.AddForce(_velocity, ForceMode.Force);
            activeEngines++;
        }
        else if (controls.Player.Booster3.IsInProgress())
        {
            _velocity += new Vector3(thruster3.forward.x, 0, thruster3.forward.z);
            rb.AddForce(_velocity, ForceMode.Force);
            activeEngines++;
        }

        if (controls.Player.Booster2.IsInProgress() && controls.Player.Booster4.IsInProgress())
        {
            activeEngines++;
            activeEngines++;
        }
        else if (controls.Player.Booster2.IsInProgress())
        {
            _velocity += new Vector3(thruster2.forward.x, 0, thruster2.forward.z);
            rb.AddForce(_velocity, ForceMode.Force);
            activeEngines++;
        }
        else if (controls.Player.Booster4.IsInProgress())
        {
            _velocity += new Vector3(thruster4.forward.x, 0, thruster4.forward.z);
            rb.AddForce(_velocity, ForceMode.Force);
            activeEngines++;
        }

        _velocity = _velocity.normalized * thrusterPower;
        rb.AddForce(_velocity, ForceMode.Force);

        currentFuel -= activeEngines * fuelConsumptionRate * Time.deltaTime;
        currentFuel = Mathf.Max(currentFuel, 0);

        if (rb.velocity.x > velocityCap)
        {
            rb.velocity = new Vector3(velocityCap, 0, rb.velocity.z);
        }
        if (rb.velocity.z > velocityCap)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, velocityCap);
        }
        if (rb.velocity.x < -velocityCap)
        {
            rb.velocity = new Vector3(-velocityCap, 0, rb.velocity.z);
        }
        if (rb.velocity.z < -velocityCap)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, -velocityCap);
        }

        if(activeEngines >= 1)
        {
            if (!thrusterSFX.isPlaying)
            {
                thrusterSFX.Play();
            }
        }
        else if (activeEngines == 0)
        {
            if (thrusterSFX.isPlaying)
            {
                thrusterSFX.Stop();
            }
        }
    }

    public void AddFuel(float fuelAmount)
    {
        currentFuel = Mathf.Clamp(currentFuel + fuelAmount, 0, maxFuel);
    }
}
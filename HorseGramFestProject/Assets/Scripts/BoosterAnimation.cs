using UnityEngine;
using UnityEngine.InputSystem;

public class BoosterAnimation : MonoBehaviour
{
    MasterInput controls;

    [SerializeField] private ParticleSystem thrusterFX1;
    [SerializeField] private ParticleSystem thrusterFX2;
    [SerializeField] private ParticleSystem thrusterFX3;
    [SerializeField] private ParticleSystem thrusterFX4;
    [SerializeField] private GameObject thrusterPowerFX1;
    [SerializeField] private GameObject thrusterPowerFX2;
    [SerializeField] private GameObject thrusterPowerFX3;
    [SerializeField] private GameObject thrusterPowerFX4;

    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        controls = new MasterInput();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }

    void Start()
    {
        Deactivate();
    }

    void Update()
    {
        // Check if fuel is empty
        if (playerMovement.CurrentFuel <= 0)
        {
            // Stop all thrusters, animation now a no go 
            StopAllThrusters();
            return;
        }
        HandleThruster(controls.Player.Booster1, thrusterFX1, thrusterPowerFX1);
        HandleThruster(controls.Player.Booster2, thrusterFX2, thrusterPowerFX2);
        HandleThruster(controls.Player.Booster3, thrusterFX3, thrusterPowerFX3);
        HandleThruster(controls.Player.Booster4, thrusterFX4, thrusterPowerFX4);
    }

    private void HandleThruster(InputAction _button, ParticleSystem _thrusterFX, GameObject _powerFX)
    {
        if (_button.WasPressedThisFrame())
        {
            _thrusterFX.Play();
            //_powerFX.SetActive(true);
        }
        else if (_button.WasReleasedThisFrame())
        {
            _thrusterFX.Stop();
            //_powerFX.SetActive(false);
        }
    }

    private void StopAllThrusters()
    {
        thrusterFX1.Stop();
        thrusterFX2.Stop();
        thrusterFX3.Stop();
        thrusterFX4.Stop();
    }

    public void Deactivate()
    {
        thrusterFX1.Stop();
        thrusterFX2.Stop();
        thrusterFX3.Stop();
        thrusterFX4.Stop();
        thrusterPowerFX1.SetActive(false);
        thrusterPowerFX2.SetActive(false);
        thrusterPowerFX3.SetActive(false);
        thrusterPowerFX4.SetActive(false);
    }
}

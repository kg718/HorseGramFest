using UnityEngine;
using UnityEngine.InputSystem;

public class BoosterAnimation : MonoBehaviour
{
    MasterInput controls;

    [SerializeField] private ParticleSystem thrusterFX1;
    [SerializeField] private ParticleSystem thrusterFX2;
    [SerializeField] private ParticleSystem thrusterFX3;
    [SerializeField] private ParticleSystem thrusterFX4;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private OxygenTimer oxygenTimer;

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
        thrusterFX1.Stop();
        thrusterFX2.Stop();
        thrusterFX3.Stop();
        thrusterFX4.Stop();
    }

    void Update()
    {
        if (oxygenTimer != null && oxygenTimer.IsOutOfOxygen)
        {
            StopAllThrusters();
            return;
        }

        if (playerMovement.CurrentFuel <= 0)
        {
            StopAllThrusters();
            return;
        }

        HandleThruster(controls.Player.Booster1, thrusterFX1);
        HandleThruster(controls.Player.Booster2, thrusterFX2);
        HandleThruster(controls.Player.Booster3, thrusterFX3);
        HandleThruster(controls.Player.Booster4, thrusterFX4);
    }

    private void HandleThruster(InputAction button, ParticleSystem thrusterFX)
    {
        if (oxygenTimer != null && oxygenTimer.IsOutOfOxygen)
        {
            thrusterFX.Stop();
            return;
        }

        if (button.WasPressedThisFrame())
        {
            thrusterFX.Play();
        }
        else if (button.WasReleasedThisFrame())
        {
            thrusterFX.Stop();
        }
    }

    public void StopAllThrusters()
    {
        thrusterFX1.Stop();
        thrusterFX2.Stop();
        thrusterFX3.Stop();
        thrusterFX4.Stop();
    }
}

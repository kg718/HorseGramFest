using UnityEngine;

public class BoosterAnimation : MonoBehaviour
{
    MasterInput controls;

    [SerializeField] private ParticleSystem thrusterFX1;
    [SerializeField] private ParticleSystem thrusterFX2;
    [SerializeField] private ParticleSystem thrusterFX3;
    [SerializeField] private ParticleSystem thrusterFX4;

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
        if(controls.Player.Booster1.WasPressedThisFrame())
        {
            thrusterFX1.Play();
        }
        else if(controls.Player.Booster1.WasReleasedThisFrame())
        {
            thrusterFX1.Stop();
        }

        if (controls.Player.Booster2.WasPressedThisFrame())
        {
            thrusterFX2.Play();
        }
        else if (controls.Player.Booster2.WasReleasedThisFrame())
        {
            thrusterFX2.Stop();
        }

        if (controls.Player.Booster3.WasPressedThisFrame())
        {
            thrusterFX3.Play();
        }
        else if (controls.Player.Booster3.WasReleasedThisFrame())
        {
            thrusterFX3.Stop();
        }

        if (controls.Player.Booster4.WasPressedThisFrame())
        {
            thrusterFX4.Play();
        }
        else if (controls.Player.Booster4.WasReleasedThisFrame())
        {
            thrusterFX4.Stop();
        }
    }
}

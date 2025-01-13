using UnityEngine;

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

    private Rigidbody rb;

    private void Awake()
    {
        controls = new MasterInput();
        controls.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 _velocity = Vector3.zero;

        if(controls.Player.Booster1.IsInProgress() && controls.Player.Booster2.IsInProgress() && controls.Player.Booster3.IsInProgress() && controls.Player.Booster4.IsInProgress())
        {
            rb.angularVelocity = Vector3.zero;
        }

        if (controls.Player.Booster1.IsInProgress() && controls.Player.Booster4.IsInProgress())
        {

        }
        else if (controls.Player.Booster1.IsInProgress())
        {
            _velocity += new Vector3(thruster1.forward.x * thrusterPower, 0, thruster1.forward.z * thrusterPower);
            rb.AddForce(_velocity, ForceMode.Force);
        }
        else if (controls.Player.Booster4.IsInProgress())
        {
            _velocity += new Vector3(thruster4.forward.x * thrusterPower, 0, thruster4.forward.z * thrusterPower);
            rb.AddForce(_velocity, ForceMode.Force);
        }

        if (controls.Player.Booster2.IsInProgress() && controls.Player.Booster3.IsInProgress())
        {

        }
        else if (controls.Player.Booster2.IsInProgress())
        {
            _velocity += new Vector3(thruster2.forward.x * thrusterPower, 0, thruster2.forward.z * thrusterPower);
            rb.AddForce(_velocity, ForceMode.Force);
        }
        else if (controls.Player.Booster3.IsInProgress())
        {
            _velocity += new Vector3(thruster3.forward.x * thrusterPower, 0, thruster3.forward.z * thrusterPower);
            rb.AddForce(_velocity, ForceMode.Force);
        }

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
    }
}

using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int health;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            foreach (ContactPoint _contact in collision.contacts)
            {
                Vector3 _velocity = new Vector3(_contact.normal.x * 10, 0, _contact.normal.z * 10);
                rb.AddForce(_velocity, ForceMode.Impulse);
            }
            TakeDamage(25);
        }
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if(health <= 0)
        {
            
        }
    }
}

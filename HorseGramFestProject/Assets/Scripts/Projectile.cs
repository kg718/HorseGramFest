
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject explosionFx;

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            collision.gameObject.GetComponent<PlayerDamage>().TakeDamage(25);
        }
        catch
        {

        }
        Instantiate(explosionFx, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}

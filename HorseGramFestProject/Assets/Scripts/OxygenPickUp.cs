using UnityEngine;

public class OxygenPickUp : MonoBehaviour
{
    [SerializeField] private int oxygenIncrease;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<OxygenTimer>().currentOxygen += oxygenIncrease;
            Destroy(gameObject);
        }
    }
}

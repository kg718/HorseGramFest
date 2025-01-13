using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}

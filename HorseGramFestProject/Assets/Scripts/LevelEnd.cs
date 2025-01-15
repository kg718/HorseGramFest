using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private Animator transitionAnimator;
    private GameObject gameOverPanel;
    private GameObject playerObject;

    void Start()
    {
        transitionAnimator = GameObject.Find("Canvas").transform.GetChild(6).gameObject.GetComponent<Animator>();
        gameOverPanel = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerObject = other.gameObject;
            playerObject.GetComponent<PlayerMovement>().hasWon = true;
            InvokeRepeating("MoveShip", 0.1f, 0.01f);
            Invoke("Transition", 0.8f);
        }
    }

    public void Transition()
    {
        transitionAnimator.Play("TransitionPanel_In");
        Invoke("EndLevel", 1.5f);
    }

    public void MoveShip()
    {
        playerObject.transform.GetChild(0).position += new Vector3(0, 0.3f, 0);
        playerObject.GetComponent<PlayerMovement>().currentFuel = 0;
        playerObject.GetComponent<BoosterAnimation>().Deactivate();
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    private void EndLevel()
    {
        gameOverPanel.SetActive(true);
        CancelInvoke("MoveShip");
    }
}

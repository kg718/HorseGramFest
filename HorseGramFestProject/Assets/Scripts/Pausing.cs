using UnityEngine;

public class Pausing : MonoBehaviour
{
    MasterInput controls;
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        controls = new MasterInput();
        controls.Enable();
    }

    void Start()
    {
        pausePanel.SetActive(false);
    }

    private void OnPause()
    {
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}

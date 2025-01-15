using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    MasterInput controls;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject continueButton;
    private EventSystem eventSystem;

    private void Awake()
    {
        controls = new MasterInput();
        controls.Enable();
    }

    void Start()
    {
        pausePanel.SetActive(false);
        eventSystem = EventSystem.current;
    }

    public void OnPause()
    {
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            eventSystem.SetSelectedGameObject(continueButton);
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void OnClickReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
    }
}

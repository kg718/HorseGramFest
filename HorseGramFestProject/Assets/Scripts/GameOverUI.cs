using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private EventSystem eventSytem;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject menuButton;

    void Start()
    {
        eventSytem = EventSystem.current;
        eventSytem.SetSelectedGameObject(retryButton);
    }

    private void Update()
    {
        if (Time.timeScale > 0 && !(eventSytem.currentSelectedGameObject == retryButton || eventSytem.currentSelectedGameObject == menuButton))
        {
            eventSytem.SetSelectedGameObject(retryButton);
        }
    }

    public void OnClickRetry()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

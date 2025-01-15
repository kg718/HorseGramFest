using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private EventSystem eventSytem;
    [SerializeField] private GameObject retryButton;

    void Start()
    {
        eventSytem = EventSystem.current;
        eventSytem.SetSelectedGameObject(retryButton);
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

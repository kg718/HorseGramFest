using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    private int index;
    private GameObject selectedBtn;

    private EventSystem eventSystem;
    [SerializeField] private AudioSource buttonTickSFX;
    [SerializeField] private AudioSource buttonPingSFX;

    private void Start()
    {
        eventSystem = EventSystem.current;
        selectedBtn = eventSystem.currentSelectedGameObject;
    }

    public void OnClickStart(int _sceneIndex)
    {
        index = _sceneIndex;
        buttonPingSFX.Play();
        transitionAnimator.Play("TransitionPanel_In");
        Invoke("loadScene", 1.5f);
    }

    private void Update()
    {
        if(selectedBtn != eventSystem.currentSelectedGameObject)
        {
            selectedBtn = eventSystem.currentSelectedGameObject;
            buttonTickSFX.Play();
        }
    }

    private void loadScene()
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}

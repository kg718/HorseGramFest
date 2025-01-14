using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    private int index;

    public void OnClickStart(int _sceneIndex)
    {
        index = _sceneIndex;
        transitionAnimator.Play("TransitionPanel_In");
        Invoke("loadScene", 1.5f);
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

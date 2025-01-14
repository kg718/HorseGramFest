using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int index;

    public void OnClickStart(int _sceneIndex)
    {
        index = _sceneIndex;
        Invoke("loadScene", 1);
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

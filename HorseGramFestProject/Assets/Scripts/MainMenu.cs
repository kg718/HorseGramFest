using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickStart(int _sceneIndex)
    {
        SceneManager.LoadSceneAsync(_sceneIndex);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}

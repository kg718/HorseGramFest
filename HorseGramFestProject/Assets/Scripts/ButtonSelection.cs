using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{
    private EventSystem eventSystem;

    void Start()
    {
        eventSystem = EventSystem.current;   
    }

    void Update()
    {
        
    }

    public void SelectButton(GameObject _button)
    {
        eventSystem.SetSelectedGameObject(_button);
    }
}

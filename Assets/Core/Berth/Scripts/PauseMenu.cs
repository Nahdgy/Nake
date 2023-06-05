using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool isPaused;

    [SerializeField] public GameObject PauseMenuUI;

    private PlayerControls PlayerControls;
    public InputAction menu;

    private void Awake()
    {
        PlayerControls = new PlayerControls();
    }

    void Update()
    {
           
    }

    private void OnEnable()
    {
        Debug.Log("escapeds");
        menu = PlayerControls.Menu.Escape;
        menu.Enable(); 

        menu.performed += Pause;

    }

    void OnDisable()
    {
        menu.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }   

    void ActivateMenu()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseMenuUI.SetActive(true);
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
    }
}

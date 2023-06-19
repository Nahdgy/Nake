using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool isPaused;

    [SerializeField] public GameObject PauseMenuUI, OtherCanvas;
    [SerializeField] private Button firstSelectedButton;

    private PlayerControls PlayerControls;
    public InputAction menu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        PlayerControls = new PlayerControls();
    }

    private void OnEnable()
    {
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
        firstSelectedButton.Select();
        isPaused = true;
        OtherCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
        OtherCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}

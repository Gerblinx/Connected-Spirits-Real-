using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class MenuControler : MonoBehaviour
{
    [SerializeField] private GameObject playerPage;
    [SerializeField] private GameObject savePage;
    [SerializeField] private GameObject loadPage;
    [SerializeField] private GameObject controlsPage;
    [SerializeField] private GameObject settingsPage;

    public GameObject menuCanvas;
    InputAction controlsAction;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        playerPage.SetActive(false);
        savePage.SetActive(false);
        loadPage.SetActive(false);
        controlsPage.SetActive(false);
        settingsPage.SetActive(false);

        controlsAction = InputSystem.actions.FindAction("Menu");

        menuCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (controlsAction.WasPressedThisFrame())
        {

            if (!isPaused)
            {
                Pause();
            }
            else
            {
                if(isPaused && controlsAction.WasPressedThisFrame())
                {
                    Unpause();
                }
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        menuCanvas.SetActive(!menuCanvas.activeSelf);
        playerPage.SetActive(true);
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menuCanvas.SetActive(!menuCanvas.activeSelf);
        playerPage.SetActive(false);
    }

    public void closePages()
    {
        if(playerPage.activeSelf == true)
        {
            playerPage.SetActive(false);
        }
        if(savePage.activeSelf == true)
        {
            savePage.SetActive(false);
        }
        if(loadPage.activeSelf == true)
        {
            loadPage.SetActive(false);
        }
        if(controlsPage.activeSelf == true)
        {
            controlsPage.SetActive(false);
        }
        if(settingsPage.activeSelf == true)
        {
            settingsPage.SetActive(false);
        }

    }


    public void PlayerTabOpen()
    {
        closePages();
        playerPage.SetActive(true);
        
    }

    public void SaveTabOpen()
    {
        closePages();
        savePage.SetActive(true);

    }

    public void LoadTabOpen()
    {
        closePages();
        loadPage.SetActive(true);

    }

    public void ControlsTabOpen()
    {
        closePages();
        controlsPage.SetActive(true);

    }

    public void SettingsTabOpen()
    {
        closePages();
        settingsPage.SetActive(true);

    }

}

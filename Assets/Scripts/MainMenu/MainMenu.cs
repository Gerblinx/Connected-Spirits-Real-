using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveLoadMenu loadSlotsMenu;


    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;
    

    private void Start()
    {
        if (!DataPersistanceManager.instance.HasGameData())
        {
            
        }
    }


    public void OnNewGameClicked()
    {
        loadSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
    }

    public void OnLoadGameClicked()
    {
        loadSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();

        //this needs to be changed to a the scene that would be saved in the json
        SceneManager.LoadSceneAsync("0MyraStart");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }



}

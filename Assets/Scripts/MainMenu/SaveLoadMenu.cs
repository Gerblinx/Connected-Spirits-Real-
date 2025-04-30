using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadMenu : MonoBehaviour
{

    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    private SaveLoadSlots[] loadSlot;

    private bool isLoadingGame = false;

    private void Awake()
    {
        loadSlot = this.GetComponentsInChildren<SaveLoadSlots>();
    }

    public void OnLoadSlotClicked(SaveLoadSlots loadSlot)
    {
        DisableMenuButtons();

        DataPersistanceManager.instance.ChangeSelectedProfileId(loadSlot.GetProfileId());

        if(!isLoadingGame)
        {
            DataPersistanceManager.instance.NewGame();
        }

        DataPersistanceManager.instance.NewGame();

        SceneManager.LoadSceneAsync("0MyraStart");
    }


    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }



    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistanceManager.instance.GetAllProfileGameData();

        
        foreach(SaveLoadSlots loadSlot in loadSlot)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(loadSlot.GetProfileId(), out profileData);
            loadSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                loadSlot.SetInteractable(false);
            }
            else
            {
                loadSlot.SetInteractable(true);
               
            }
        }

        

    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void DisableMenuButtons()
    {
        foreach(SaveLoadSlots loadSlot in loadSlot)
        {
            loadSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }



}

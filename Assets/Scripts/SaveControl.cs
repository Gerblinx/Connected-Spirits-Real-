using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveControl : MonoBehaviour
{
    private string saveLocation;
    private InventoryControl inventoryControl;

    // Start is called before the first frame update
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");

        inventoryControl = FindObjectOfType<InventoryControl>();
    }

    public void SaveGame()
    {
        SAVEDATA saveData = new SAVEDATA
        {
            playerPosistion = GameObject.FindGameObjectWithTag("Player").transform.position,
            inventorySaveData = inventoryControl.GetInventoryItems()
        };

        PlayerPrefs.SetInt("SceneSaved", SceneManager.GetActiveScene().buildIndex);
        
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }


    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SAVEDATA savedData = JsonUtility.FromJson<SAVEDATA>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Player").transform.position = savedData.playerPosistion;

            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSaved"));

            inventoryControl.SetInventoryItems(savedData.inventorySaveData);

            Time.timeScale = 1f;
        }
        else
        {
            SaveGame();
            inventoryControl.SetInventoryItems(new List<InventorySaveData>());
        }

    }

}

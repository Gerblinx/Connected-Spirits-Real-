using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadSlots : MonoBehaviour
{

    [Header("Profile")]

    [SerializeField] private string profileId = "";

    [Header("Content")]

    [SerializeField] private GameObject noData;
    [SerializeField] private GameObject hasData;
    [SerializeField] private TextMeshProUGUI precentageText;
    [SerializeField] private TextMeshProUGUI character;

    private Button loadSlotButton;

    private void Awake()
    {
        loadSlotButton = this.GetComponent<Button>();
    }


    public void SetData(GameData data)
    {
        if(data == null)
        {
            noData.SetActive(true);
            hasData.SetActive(false);
        }
        else
        {
            noData.SetActive(false);
            hasData.SetActive(true);
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        loadSlotButton.interactable = interactable;
    }


}

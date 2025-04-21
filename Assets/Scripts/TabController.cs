using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TabController: MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    private PlayerControls playerControls;
    public int tabOn;
    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
        
        ActivateTab(0);
        
        
    }

    public void ActivateTab(int TabNO)
    {
        
        for(int i = 0; i < tabImages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[TabNO].SetActive(true);
        tabImages[TabNO].color = Color.white;

    }


    public void OnClick()
    {
        
        
        Debug.Log("Click");
    }


}

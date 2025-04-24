using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabControler : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;

    // Start is called before the first frame update
    void Start()
    {
        ActiveTab(0);
    }

    // Update is called once per frame
    public void ActiveTab(int tabNO)
    {
        
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[tabNO].SetActive(true);
        tabImages[tabNO].color = Color.white;


    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Activate : MonoBehaviour
{
    private PlayerControls playerControls;
   
    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
        
        
        
    }

   public void OnClick()
    {
       

        Debug.Log("Click");
    }

}

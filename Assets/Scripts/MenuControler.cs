using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuControler : MonoBehaviour
{
    public GameObject menuCanvas;
    InputAction controlsAction;

    // Start is called before the first frame update
    void Start()
    {
        controlsAction = InputSystem.actions.FindAction("Menu");

        menuCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (controlsAction.WasPressedThisFrame())
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public GameObject menuCanvas;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {

            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }

        }


    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        menuCanvas.SetActive(true);

    }

    private void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menuCanvas.SetActive(false);
    }
}

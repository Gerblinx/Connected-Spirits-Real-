using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryCanvas;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        inventoryCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
        inventoryCanvas.SetActive(true);
    }

    private void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        inventoryCanvas.SetActive(false);
    }
}

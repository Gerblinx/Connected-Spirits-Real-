using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionRoom : MonoBehaviour
{
    public string roomName;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(roomName);
        }

    }

    
}

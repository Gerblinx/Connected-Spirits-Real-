using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour, IDataPersistence
{
    public GameObject player;
    
    public void LoadData(GameData data)
    {
        player = GetComponent<GameObject>();

        player.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = player.transform.position;
    }
}

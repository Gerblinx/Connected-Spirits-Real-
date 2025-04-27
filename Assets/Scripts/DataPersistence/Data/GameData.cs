using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    //I need to put Health bar, mental health bar, toxic level bar and maybe another thing

    public Vector3 playerPosition;
    //and probably inventory data

    public GameData()
    {
        playerPosition = Vector3.zero;
    }



}

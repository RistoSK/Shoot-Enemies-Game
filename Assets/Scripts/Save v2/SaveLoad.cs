using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public void Save(PlayerInfo playerInfo)
    {
        SavingService.SaveGame(playerInfo);
    }
    

    public bool Load(PlayerInfo playerInfo)
    {
        return SavingService.LoadGame(playerInfo);
    }
}
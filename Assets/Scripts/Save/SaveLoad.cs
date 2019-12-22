using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public void Save(AccountInfo accountInfo)
    {
        SavingService.SaveGame(accountInfo);
    }
    
    public bool Load(AccountInfo accountInfo)
    {
        return SavingService.LoadGame(accountInfo);
    }
}
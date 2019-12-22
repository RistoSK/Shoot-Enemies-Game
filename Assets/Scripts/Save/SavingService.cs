using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingService
{
    private const string SavedPathAddress = "/shootenemies.save";
    
    public static void SaveGame(AccountInfo accountInfo)
    {
        Save save = CreateSaveGameObject(accountInfo);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + SavedPathAddress);
        var json = JsonUtility.ToJson(save);
        bf.Serialize(file, json);
        file.Close();
    }
    
    private static Save CreateSaveGameObject(AccountInfo accountInfo)
    {
        Save save = new Save
        {
            UserName = accountInfo.UserName, Password = accountInfo.Password, HighScore = accountInfo.HighScore
        };
        
        return save;
    }

    public static bool LoadGame(AccountInfo accountInfo)
    {
        if (File.Exists(Application.persistentDataPath + SavedPathAddress))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + SavedPathAddress, FileMode.Open);
            Save save = new Save();
            JsonUtility.FromJsonOverwrite((string) bf.Deserialize(file), save);
            file.Close();

            accountInfo.UserName = save.UserName;
            accountInfo.Password = save.Password;
            accountInfo.HighScore = save.HighScore;
            
            return true;
        }
        
        return false;
    }
}

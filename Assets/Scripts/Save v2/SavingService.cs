using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingService
{
    private const string SavedPathAddress = "/shootenemies.save";
    
    public static void SaveGame(PlayerInfo playerInfo)
    {
        Save save = CreateSaveGameObject(playerInfo);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + SavedPathAddress);
        var json = JsonUtility.ToJson(save);
        bf.Serialize(file, json);
        file.Close();
    }
    
    private static Save CreateSaveGameObject(PlayerInfo playerInfo)
    {
        Save save = new Save
        {
            UserName = playerInfo.UserName, Password = playerInfo.Password, HighScore = playerInfo.HighScore
        };


        return save;
    }

    public static bool LoadGame(PlayerInfo playerInfo)
    {
        if (File.Exists(Application.persistentDataPath + SavedPathAddress))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + SavedPathAddress, FileMode.Open);
            Save save = new Save();
            JsonUtility.FromJsonOverwrite((string) bf.Deserialize(file), save);
            file.Close();

            playerInfo.UserName = save.UserName;
            playerInfo.Password = save.Password;
            playerInfo.HighScore = save.HighScore;
            
            return true;
        }
        
        return false;
    }
}

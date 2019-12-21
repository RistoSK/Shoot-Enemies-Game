using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;

    private const string SavedPathAddress = "/shootenemies.save";
    
    public static GameManager Instance;

    public Action OnLoggingSuccessful;
    public Action OnLoggingFailed;
    
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    private void Start()
    {
        LoadGame();
    }

    private void OnEnable()
    {
        //MainScreenController.Instance.OnSignUpComplete += SaveGame;
        //ScoreManager.Instance.OnNewHighScoreArchived += SaveGame;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + SavedPathAddress);
        var json = JsonUtility.ToJson(save);
        bf.Serialize(file, json);
        file.Close();
    }
    
    private Save CreateSaveGameObject()
    {
        Save save = new Save
        {
            UserName = _playerInfo.UserName, Password = _playerInfo.Password, HighScore = _playerInfo.HighScore
        };


        return save;
    }
    
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + SavedPathAddress))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + SavedPathAddress, FileMode.Open);
            Save save = new Save();
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), save);
            file.Close();

            _playerInfo.UserName = save.UserName;
            _playerInfo.Password = save.Password;
            _playerInfo.HighScore = save.HighScore;

            // if (MainScreenController.Instance)
            // {
            //     MainScreenController.Instance.LoggingSucceeded(); 
            // }
            OnLoggingSuccessful?.Invoke();

        }
        else
        {
            // if (MainScreenController.Instance)
            // {
            //     MainScreenController.Instance.LoggingFailed();
            // }
            OnLoggingFailed?.Invoke();
        }
    }
}

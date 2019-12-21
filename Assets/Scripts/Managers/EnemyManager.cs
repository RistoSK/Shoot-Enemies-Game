using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    // TODO REMOVE THIS
    [SerializeField] private GameMode _easyMode;
    
    public Action<int> OnPointsGained;
    public Action OnGameFinished;
    
    private GameMode _gameMode;

    public GameMode CurrentGameMode => _gameMode;
    
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
        
        //TODO REMOVE IT IS FOR TESTING PURPOSES
        _gameMode = _easyMode;
        //////////////////////////////////////////////////////////////
    }

    private void Start()
    {
        GameScreenManager.Instance.OnGameModeSelected += SetGameMode;
        PlayerManager.Instance.OnGameOver += DeactivateAllEnemies;
    }

    private void SetGameMode(GameMode gameMode)
    {
        _gameMode = gameMode;
    }

    public void PointsGained(int points)
    {
        OnPointsGained?.Invoke(points);
    }

    private void DeactivateAllEnemies()
    {
        OnGameFinished?.Invoke();    
    }
}

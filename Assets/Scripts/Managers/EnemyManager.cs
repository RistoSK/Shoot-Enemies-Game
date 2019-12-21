using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    // TODO REMOVE THIS
    [SerializeField] private GameMode _easyMode;
    
    [SerializeField] private EnemySpawner _enemySpawner;
    
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
        GameRootController.Instance.OnGameModeSelected += SetGameMode;
        GameRootController.Instance.OnGameStarted += StartSpawning;

        if (!_enemySpawner)
        {
            Debug.LogError("EnemySpawner has not been set");
        }
    }

    private void StartSpawning()
    {
        _enemySpawner.ShouldSpawn(true);
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
        
        _enemySpawner.ShouldSpawn(false);
    }
}

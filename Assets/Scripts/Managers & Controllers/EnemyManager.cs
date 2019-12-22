using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    
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
    }

    private void Start()
    {
        PlayerController.Instance.OnGameOver += DeactivateAllEnemies;
        GameRootController.Instance.OnGameModeSelected += SetGameMode;
        GameRootController.Instance.OnGameStarted += StartSpawning;

        if (!_enemySpawner)
        {
            Debug.LogError("Enemy Spawner has not been set");
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

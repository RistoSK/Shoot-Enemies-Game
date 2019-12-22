using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public Action<int> OnPointsGained;

    private int _currentScore = 0;

    public int CurrentScore => _currentScore;
    
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
        EnemyManager.Instance.OnPointsGained += PointsGained;
        GameRootController.Instance.OnGameStarted += ResetCurrentPoints;
    }

    private void ResetCurrentPoints()
    {
        _currentScore = 0;
    }

    private void PointsGained(int points)
    {
        _currentScore += points;
        
        OnPointsGained?.Invoke(_currentScore);
    }
}

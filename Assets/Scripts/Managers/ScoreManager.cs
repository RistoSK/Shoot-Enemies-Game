using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    
    public static ScoreManager Instance;
    
    public Action<int> OnNewHighScoreArchived;
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
        //PlayerManager.Instance.OnGameOver += GameSessionFinished;
    }
    

    // private void GameSessionFinished()
    // {
    //     if (_currentScore > _playerInfo.HighScore)
    //     {
    //         OnNewHighScoreArchived?.Invoke(_currentScore);
    //     }
    // }

    private void PointsGained(int points)
    {
        _currentScore += points;
        
        OnPointsGained?.Invoke(_currentScore);
    }
}

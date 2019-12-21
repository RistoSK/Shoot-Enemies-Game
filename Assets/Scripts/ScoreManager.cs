using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private SaveLoad _saveLoad;
    
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _userNameText;

    [SerializeField] private TextMeshProUGUI _gameOverCurrentScore;
    [SerializeField] private TextMeshProUGUI _gameOverScore;
    
    [SerializeField] private PlayerInfo _playerInfo;

    public static ScoreManager Instance;
    
    public Action OnNewHighScoreArchived;
    
    private int _currentScore = 0;
    
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
        _userNameText.text = _playerInfo.UserName;

        ResetScoreValues();

        EnemyManager.Instance.OnPointsGained += PointsGained;
        PlayerManager.Instance.OnGameOver += GameSessionFinished;
        GameScreenManager.Instance.OnGameStarted += ResetScoreValues;
    }

    private void ResetScoreValues()
    {
        _currentScore = 0;
        _currentScoreText.text = "0";
        _highScoreText.text = _playerInfo.HighScore.ToString();
    }

    private void GameSessionFinished()
    {
        _gameOverCurrentScore.text = _currentScore.ToString();
        
        if (_currentScore > _playerInfo.HighScore)
        {
            _playerInfo.HighScore = _currentScore;
            
            //GameManager.Instance.SaveGame();
            _saveLoad.Save(_playerInfo);
        }

        _gameOverScore.text = _playerInfo.HighScore.ToString();
    }

    private void PointsGained(int points)
    {
        _currentScore += points;
        _currentScoreText.text = _currentScore.ToString();
    }
}

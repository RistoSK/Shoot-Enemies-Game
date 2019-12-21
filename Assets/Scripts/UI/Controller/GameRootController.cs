using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRootController : MonoBehaviour
{
    [SerializeField] private GameDifficultyController _gameDifficultyController;
    [SerializeField] private GameOverController _gameOverController;
    [SerializeField] private GameController _gameController;

    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private PlayerInfo _playerInfo;

    public static GameRootController Instance;

    public Action<GameMode> OnGameModeSelected;
    public Action OnGameStarted;
    
    public PlayerInfo PlayerInfo => _playerInfo;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _gameDifficultyController.GameRoot = this;
        _gameOverController.GameRoot = this;
        _gameController.GameRoot = this;

        ScoreManager.Instance.OnPointsGained += UpdateCurrentScore;
        ScoreManager.Instance.OnNewHighScoreArchived += HighScoreArchived;
        PlayerManager.Instance.OnGameOver += GameOver;

        ActivateDifficultyChoiceScreen();
    }

    private void GameOver()
    {
        if (ScoreManager.Instance.CurrentScore > _playerInfo.HighScore)
        {
            _playerInfo.HighScore = ScoreManager.Instance.CurrentScore;
        }
        
        ActivateGameOverScreen();
    }

    public int GetCurrentPoints()
    {
        return ScoreManager.Instance.CurrentScore;
    }
    
    public void GameModeSelected(GameMode selectedGameMode)
    {
        OnGameModeSelected?.Invoke(selectedGameMode);

        ActivateGameScreen();
    }

    private void HighScoreArchived(int newHighScore)
    {
        _playerInfo.HighScore = newHighScore;
        
        _saveLoad.Save(_playerInfo);
    }

    private void UpdateCurrentScore(int currentScore)
    {
        _gameController.UpdateCurrentScoreView(currentScore);
    }

    public void ActivateDifficultyChoiceScreen()
    {
        DisableControllers();
        _gameDifficultyController.InitiateController();
    }

    private void ActivateGameScreen()
    {
        DisableControllers();
        _gameController.InitiateController();
        
        OnGameStarted?.Invoke();
    }

    private void ActivateGameOverScreen()
    {
        DisableControllers();
        _gameOverController.InitiateController();
    }
    
    // public void SignUpCompleted()
    // {
    //     LoggingSucceeded();
    // }
    //
    // public void PlayPressed()
    // {
    //     SceneManager.LoadScene(1);
    // }
    //
    // private void LoggingFailed()
    // {
    //     DisableControllers();
    //     _gameOverController.InitiateController();
    // }

    private void DisableControllers()
    {
        _gameDifficultyController.DisableController();
        _gameOverController.DisableController();
    }
}
using System;
using UnityEngine;

public class GameRootController : MonoBehaviour
{
    [SerializeField] private GameDifficultyController _gameDifficultyController;
    [SerializeField] private GameOverController _gameOverController;
    [SerializeField] private GameController _gameController;

    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private AccountInfo _accountInfo;

    public static GameRootController Instance;

    public Action<GameMode> OnGameModeSelected;
    public Action OnGameStarted;
    
    public AccountInfo AccountInfo => _accountInfo;

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
        
        if (!_gameDifficultyController)
        {
            Debug.LogError("Game Difficulty Controller has not been assigned");
        }
        
        if (!_gameOverController)
        {
            Debug.LogError("Game Over Controller has not been assigned");
        }
        
        if (!_gameController)
        {
            Debug.LogError("Game Controller has not been assigned");
        }

        if (!_saveLoad)
        {
            Debug.LogError("Save Load has not been assigned");    
        }

        if (!_accountInfo)
        {
            Debug.LogError("Account Info has not been assigned");
        }
    }

    private void Start()
    {
        _gameDifficultyController.GameRoot = this;
        _gameOverController.GameRoot = this;
        _gameController.GameRoot = this;

        ScoreManager.Instance.OnPointsGained += UpdateCurrentScore;
        PlayerController.Instance.OnGameOver += GameOver;

        ActivateDifficultyChoiceScreen();
    }

    private void GameOver()
    {
        if (ScoreManager.Instance.CurrentScore > _accountInfo.HighScore)
        {
            HighScoreArchived(ScoreManager.Instance.CurrentScore);
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
        _accountInfo.HighScore = newHighScore;
        
        _saveLoad.Save(_accountInfo);
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

    private void DisableControllers()
    {
        _gameDifficultyController.DisableController();
        _gameOverController.DisableController();
        _gameController.DisableController();
    }
}
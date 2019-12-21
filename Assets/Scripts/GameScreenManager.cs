using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenManager : MonoBehaviour
{
    [SerializeField] private GameMode _easyMode;
    [SerializeField] private GameMode _mediumMode;
    [SerializeField] private GameMode _hardMode;

    [SerializeField] private Canvas _gameDifficultyCanvas;
    [SerializeField] private Canvas _gameOverCanvas;

    public static GameScreenManager Instance;
    
    public Action<GameMode> OnGameModeSelected;
    public Action OnGameStarted;

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
        PlayerManager.Instance.OnGameOver += GameOver;
        
        _gameDifficultyCanvas.enabled = true;
        _gameOverCanvas.enabled = false;
        
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
       
    }

    public void InitiateEasyMode()
    {
        OnGameModeSelected?.Invoke(_easyMode);
        StartGame();
    }

    public void InitiateMediumMode()
    {
        OnGameModeSelected?.Invoke(_mediumMode);
        StartGame();
    }

    public void InitiateHardMode()
    {
        OnGameModeSelected?.Invoke(_hardMode);
        StartGame();
    }

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameDifficultyCanvas.enabled = true;
        _gameOverCanvas.enabled = false;

        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    private void StartGame()
    {
        Time.timeScale = 1f;
        _gameDifficultyCanvas.enabled = false;
        
        OnGameStarted?.Invoke();
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        
        _gameOverCanvas.enabled = true;
    }
}

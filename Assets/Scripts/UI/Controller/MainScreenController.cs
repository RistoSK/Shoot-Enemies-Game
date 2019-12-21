using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenController : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private SaveLoad _saveLoad;
    
    [SerializeField] private Canvas _loginScreenCanvas;
    [SerializeField] private Canvas _mainScreenCanvas;
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private TextMeshProUGUI _userNameText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    
    public static MainScreenController Instance;

    public Action OnSignUpComplete;
    
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
        if (_saveLoad.Load(_playerInfo))
        {
            LoggingSucceeded();
        }
        else
        {
            LoggingFailed();
        }
    }

    public void SignUp()
    {
        _playerInfo.UserName = _usernameInputField.text;
        _playerInfo.Password = _passwordInputField.text;
        _playerInfo.HighScore = 0;

        LoggingSucceeded();
        
        //OnSignUpComplete?.Invoke();
        _saveLoad.Save(_playerInfo);
        //GameManager.Instance.SaveGame();
    }

    public void LoggingFailed()
    {
        OpenLoginScreen();
    }

    public void LoggingSucceeded()
    {
        OpenMainScreen();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    
    private void OpenLoginScreen()
    {
        _loginScreenCanvas.enabled = true;
        _mainScreenCanvas.enabled = false;
    }

    private void OpenMainScreen()
    {
        _userNameText.text = _playerInfo.UserName;
        _highScoreText.text = _playerInfo.HighScore.ToString();
        
        _loginScreenCanvas.enabled = false;
        _mainScreenCanvas.enabled = true;
    }

}


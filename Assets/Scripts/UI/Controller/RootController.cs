using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootController : MonoBehaviour
{
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private LoginController _loginController;

    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private PlayerInfo _playerInfo;

    public PlayerInfo PlayerInfo => _playerInfo;
    
    private void Start()
    {
        _mainMenuController.Root = this;
        _loginController.Root = this;

        if (_saveLoad.Load(_playerInfo))
        {
            LoggingSucceeded();
        }
        else
        {
            LoggingFailed();
        }
    }

    public void SignUpCompleted()
    {
        LoggingSucceeded();
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene(1);
    }
    
    private void LoggingFailed()
    {
        DisableControllers();
        _loginController.InitiateController();
    }

    private void LoggingSucceeded()
    {
        _saveLoad.Save(_playerInfo);
        
        DisableControllers();
        _mainMenuController.InitiateController();
    }
    
    private void DisableControllers()
    {
        _mainMenuController.DisableController();
        _loginController.DisableController();
    }
}

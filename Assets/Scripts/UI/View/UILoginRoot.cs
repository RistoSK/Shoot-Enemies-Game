using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILoginRoot : UIRoot
{
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;

    [SerializeField] private UILoginView _loginView;

    public UILoginView LoginView => _loginView;
    
    public void SetPlayerInformation(PlayerInfo playerInfo)
    {
        playerInfo.UserName = _usernameInputField.text;
        playerInfo.Password = _passwordInputField.text;
        playerInfo.HighScore = 0;
    }
}

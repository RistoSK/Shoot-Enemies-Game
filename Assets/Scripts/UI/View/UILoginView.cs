using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILoginView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    
    public Action OnSignUpClicked;
    
    public void SignUpClicked()
    {
        OnSignUpClicked?.Invoke();
    }
    
    public void SetPlayerInformation(PlayerInfo playerInfo)
    {
        playerInfo.UserName = _usernameInputField.text;
        playerInfo.Password = _passwordInputField.text;
        playerInfo.HighScore = 0;
    }
}

using System;
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
    
    public void SetPlayerInformation(AccountInfo accountInfo)
    {
        accountInfo.UserName = _usernameInputField.text;
        accountInfo.Password = _passwordInputField.text;
        accountInfo.HighScore = 0;
    }
}

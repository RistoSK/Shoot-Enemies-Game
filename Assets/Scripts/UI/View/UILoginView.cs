using System;
using TMPro;
using UnityEngine;

public class UILoginView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    
    public Action OnSignUpClicked;

    private void Awake()
    {
        if (!_usernameInputField)
        {
            Debug.LogError("Username Input Field has not been assigned");
        }

        if (!_passwordInputField)
        {
            Debug.LogError("Password Input Field has not been assigned");
        }
    }

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

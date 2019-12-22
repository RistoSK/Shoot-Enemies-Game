using System;
using TMPro;
using UnityEngine;

public class UIMainMenuView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userNameText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    
    public Action OnPlayClicked;
    
    public void Awake()
    {
        if (!_userNameText)
        {
            Debug.LogError("Username Text has not been assigned");
        }
        
        if (!_highScoreText)
        {
            Debug.LogError("High Score Text has not been assigned");
        }
    }
    
    public void PlayClicked()
    {
        OnPlayClicked?.Invoke();
    }
    
    public void UpdatePlayerInformation(AccountInfo accountInfo)
    {
        _userNameText.text = accountInfo.UserName;
        _highScoreText.text = accountInfo.HighScore.ToString();
    }
}

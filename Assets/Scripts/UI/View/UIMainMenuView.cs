using System;
using TMPro;
using UnityEngine;

public class UIMainMenuView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userNameText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    
    public Action OnPlayClicked;
    
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

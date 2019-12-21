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
    
    public void UpdatePlayerInformation(PlayerInfo playerInfo)
    {
        _userNameText.text = playerInfo.UserName;
        _highScoreText.text = playerInfo.HighScore.ToString();
    }
}

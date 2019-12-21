using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private TextMeshProUGUI _userNameText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    
    [SerializeField] private UIMainMenuView _mainMenuView;

    public UIMainMenuView MainMenuView => _mainMenuView;

    public void UpdatePlayerInformation(PlayerInfo playerInfo)
    {
        _userNameText.text = playerInfo.UserName;
        _highScoreText.text = playerInfo.HighScore.ToString();
    }
}

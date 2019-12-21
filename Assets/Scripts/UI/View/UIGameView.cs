using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private TextMeshProUGUI _userName;

    public void InitiateValues(PlayerInfo playerInfo)
    {
        _userName.text = playerInfo.UserName;
        _highScore.text = playerInfo.HighScore.ToString();
        _currentScore.text = "0";
    }

    public void SetCurrentScore(int currentScore)
    {
        _currentScore.text = currentScore.ToString();
    }
}

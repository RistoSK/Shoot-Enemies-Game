using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOverView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    
    public Action OnResetClicked;
    public Action OnQuitClicked;

    public void ResetGame()
    {
        OnResetClicked?.Invoke();
    }

    public void QuitGame()
    {
        OnQuitClicked?.Invoke();   
    }

    public void UpdateScoreValues(PlayerInfo playerInfo, int currentPoints)
    {
        _highScore.text = playerInfo.HighScore.ToString();
        _currentScore.text = currentPoints.ToString();
    }
}

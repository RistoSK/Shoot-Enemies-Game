using System;
using TMPro;
using UnityEngine;

public class UIGameOverView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    
    public Action OnResetClicked;
    public Action OnQuitClicked;

    public void Awake()
    {
        if (!_currentScore)
        {
            Debug.LogError("Current Score Text has not been assigned");
        }
        
        if (!_highScore)
        {
            Debug.LogError("High Score Text has not been assigned");
        }
    }
    
    public void ResetGame()
    {
        OnResetClicked?.Invoke();
    }

    public void QuitGame()
    {
        OnQuitClicked?.Invoke();   
    }

    public void UpdateScoreValues(AccountInfo accountInfo, int currentPoints)
    {
        _highScore.text = accountInfo.HighScore.ToString();
        _currentScore.text = currentPoints.ToString();
    }
}

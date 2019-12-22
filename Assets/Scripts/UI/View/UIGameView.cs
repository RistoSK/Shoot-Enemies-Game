using TMPro;
using UnityEngine;

public class UIGameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private TextMeshProUGUI _userName;

    private void Awake()
    {
        if (!_currentScore)
        {
            Debug.LogError("Current Score Text has not been assigned");
        }
        
        if (!_highScore)
        {
            Debug.LogError("High Score Text has not been assigned");
        }

        if (!_userName)
        {
            Debug.LogError("User Name Text has not been assigned");
        }
    }
    
    public void InitiateValues(AccountInfo accountInfo)
    {
        _userName.text = accountInfo.UserName;
        _highScore.text = accountInfo.HighScore.ToString();
        _currentScore.text = "0";
    }

    public void SetCurrentScore(int currentScore)
    {
        _currentScore.text = currentScore.ToString();
    }
}

using TMPro;
using UnityEngine;

public class UIGameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private TextMeshProUGUI _userName;

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

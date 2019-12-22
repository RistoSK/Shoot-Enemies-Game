using UnityEngine;

[CreateAssetMenu(fileName = "AccountInfo", menuName = "AccountInfo")]
public class AccountInfo : ScriptableObject
{
    public string UserName;
    public string Password;
    public int HighScore;
}

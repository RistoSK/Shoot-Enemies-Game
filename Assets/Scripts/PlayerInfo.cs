using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public string UserName;
    public string Password;
    public int HighScore;
}

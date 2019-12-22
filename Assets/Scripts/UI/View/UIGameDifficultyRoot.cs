using UnityEngine;

public class UIGameDifficultyRoot : UIRoot
{
    [SerializeField] private UIGameDifficultyView _gameDifficultyView;

    public UIGameDifficultyView GameDifficultyView => _gameDifficultyView;
}

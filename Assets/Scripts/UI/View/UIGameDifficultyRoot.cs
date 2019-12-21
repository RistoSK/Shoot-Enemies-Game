using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameDifficultyRoot : UIRoot
{
    [SerializeField] private UIGameDifficultyView _gameDifficultyView;

    public UIGameDifficultyView GameDifficultyView => _gameDifficultyView;
}

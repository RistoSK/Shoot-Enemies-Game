using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyController : BaseController<UIGameDifficultyRoot>
{
    [SerializeField] private GameMode _easyMode;
    [SerializeField] private GameMode _mediumMode;
    [SerializeField] private GameMode _hardMode;
    
    public override void InitiateController()
    {   
        ui.GameDifficultyView.OnEasyClicked += InitiateEasyMode;
        ui.GameDifficultyView.OnMediumClicked += InitiateMediumMode;
        ui.GameDifficultyView.OnHardClicked += InitiateHardMode;
        
        base.InitiateController();
    }
    
    public override void DisableController()
    {
        base.DisableController();

        ui.GameDifficultyView.OnEasyClicked -= InitiateEasyMode;
        ui.GameDifficultyView.OnMediumClicked -= InitiateMediumMode;
        ui.GameDifficultyView.OnHardClicked -= InitiateHardMode;
    }

    private void InitiateHardMode()
    {
       GameRoot.GameModeSelected(_hardMode);
    }

    private void InitiateMediumMode()
    {
        GameRoot.GameModeSelected(_mediumMode);
    }

    private void InitiateEasyMode()
    {
        GameRoot.GameModeSelected(_easyMode);
    }
}

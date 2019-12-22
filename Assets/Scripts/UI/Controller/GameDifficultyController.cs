using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyController : BaseController<UIGameDifficultyRoot>
{
    [SerializeField] private GameMode _easyMode;
    [SerializeField] private GameMode _mediumMode;
    [SerializeField] private GameMode _hardMode;

    private void Start()
    {
        if (!_easyMode)
        {
            Debug.LogError("Easy mode has not been assigned");
        }
        
        if (!_mediumMode)
        {
            Debug.LogError("Medium mode has not been assigned");
        }
        
        if (!_hardMode)
        {
            Debug.LogError("Hard mode has not been assigned");
        }
    }
    
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

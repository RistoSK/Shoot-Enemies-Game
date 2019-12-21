using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : BaseController<UIGameOverRoot>
{
    public override void InitiateController()
    {   
        ui.GameOverView.OnResetClicked += ChangeDifficulty;
        ui.GameOverView.OnQuitClicked += QuitGame;
        
        ui.GameOverView.UpdateScoreValues(GameRoot.PlayerInfo, GameRoot.GetCurrentPoints());
            
        base.InitiateController();
    }
    
    public override void DisableController()
    {
        base.DisableController();

        ui.GameOverView.OnResetClicked -= ChangeDifficulty;
        ui.GameOverView.OnQuitClicked -= QuitGame;
    }
    
    private void QuitGame()
    {
       Application.Quit();
    }

    private void ChangeDifficulty()
    {
        GameRoot.ActivateDifficultyChoiceScreen();
    }

} 

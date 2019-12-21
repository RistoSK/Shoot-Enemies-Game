using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController<UIGameRoot>
{
    public override void InitiateController()
    {   
        ui.GameView.InitiateValues(GameRoot.PlayerInfo);
            
        base.InitiateController();
    }
    
    // public override void DisableController()
    // {
    //     base.DisableController();
    // }
    
    public void UpdateCurrentScoreView(int currentScore)
    {
        ui.GameView.SetCurrentScore(currentScore);
    }
}

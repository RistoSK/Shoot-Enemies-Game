using UnityEngine;

public class MainMenuController : BaseController<UIMainMenuRoot>
{
    public override void InitiateController()
    {
        ui.MainMenuView.OnPlayClicked += StartGame;
        ui.UpdatePlayerInformation(Root.PlayerInfo);
        
        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();
        
        ui.MainMenuView.OnPlayClicked -= StartGame;
    }

    private void StartGame()
    {
        Root.PlayPressed();
    }
}

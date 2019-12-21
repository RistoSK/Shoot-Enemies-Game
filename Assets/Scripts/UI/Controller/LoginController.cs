using TMPro;
using UnityEngine;

public class LoginController : BaseController<UILoginRoot>
{
    public override void InitiateController()
    {   
        ui.LoginView.OnSignUpClicked += SignUp;
        
        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.LoginView.OnSignUpClicked -= SignUp;
    }

    private void SignUp()
    {
        ui.SetPlayerInformation(Root.PlayerInfo);
        Root.SignUpCompleted();
    }
}

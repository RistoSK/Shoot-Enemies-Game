﻿public class LoginController : BaseController<UILoginRoot>
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
        ui.LoginView.SetPlayerInformation(Root.AccountInfo);
        Root.SignUpCompleted();
    }
}

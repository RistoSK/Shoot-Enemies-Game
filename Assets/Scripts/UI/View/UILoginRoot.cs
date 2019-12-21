using UnityEngine;

public class UILoginRoot : UIRoot
{
    [SerializeField] private UILoginView _loginView;

    public UILoginView LoginView => _loginView;
}

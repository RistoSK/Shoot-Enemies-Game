using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private UIMainMenuView _mainMenuView;

    public UIMainMenuView MainMenuView => _mainMenuView;
}

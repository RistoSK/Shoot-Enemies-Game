using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private UIMainMenuView _mainMenuView;

    public UIMainMenuView MainMenuView => _mainMenuView;
}

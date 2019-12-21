using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot : UIRoot
{
    [SerializeField] private UIGameView _gameView;

    public UIGameView GameView => _gameView;
}

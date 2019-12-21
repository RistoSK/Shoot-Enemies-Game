using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverRoot : UIRoot
{
    [SerializeField] private UIGameOverView _gameoverView;

    public UIGameOverView GameOverView => _gameoverView;
}

using UnityEngine;

public class UIGameOverRoot : UIRoot
{
    [SerializeField] private UIGameOverView _gameOverView;

    public UIGameOverView GameOverView => _gameOverView;
}

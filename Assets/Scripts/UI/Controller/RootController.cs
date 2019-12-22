using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class RootController : MonoBehaviour
{
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private LoginController _loginController;

    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private AccountInfo _accountInfo;

    public AccountInfo AccountInfo => _accountInfo;
    
    private void Start()
    {
        _mainMenuController.Root = this;
        _loginController.Root = this;

        if (_saveLoad.Load(_accountInfo))
        {
            LoggingSucceeded();
        }
        else
        {
            LoggingFailed();
        }
    }

    public void SignUpCompleted()
    {
        LoggingSucceeded();
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene(1);
    }
    
    private void LoggingFailed()
    {
        DisableControllers();
        _loginController.InitiateController();
    }

    private void LoggingSucceeded()
    {
        _saveLoad.Save(_accountInfo);
        
        DisableControllers();
        _mainMenuController.InitiateController();
    }
    
    private void DisableControllers()
    {
        _mainMenuController.DisableController();
        _loginController.DisableController();
    }
}

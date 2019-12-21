using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuView : MonoBehaviour
{
    public Action OnPlayClicked;
    
    public void PlayClicked()
    {
        OnPlayClicked?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoginView : MonoBehaviour
{
    public Action OnSignUpClicked;
    
    public void SignUpClicked()
    {
        OnSignUpClicked?.Invoke();
    }
}

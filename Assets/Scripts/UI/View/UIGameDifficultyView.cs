using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameDifficultyView : MonoBehaviour
{
    public Action OnEasyClicked;
    public Action OnMediumClicked;
    public Action OnHardClicked;

    public void EasyDifficultyClicked()
    {
        OnEasyClicked?.Invoke();
    }
    
    public void MediumDifficultyClicked()
    {
        OnMediumClicked?.Invoke();
    }
    
    public void HardDifficultyClicked()
    {
        OnHardClicked?.Invoke();
    }
}

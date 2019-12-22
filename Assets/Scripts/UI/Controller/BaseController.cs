﻿using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [HideInInspector] public RootController Root;
    [HideInInspector] public GameRootController GameRoot;

    public virtual void InitiateController()
    {
        gameObject.SetActive(true);
    }

    public virtual void DisableController()
    {
        gameObject.SetActive(false);
    }
}

public abstract class BaseController<T> : BaseController where T : UIRoot
{
    [SerializeField] protected T ui;

    public override void InitiateController()
    {
        base.InitiateController();

        ui.ShowRoot();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.HideRoot();
    }
}
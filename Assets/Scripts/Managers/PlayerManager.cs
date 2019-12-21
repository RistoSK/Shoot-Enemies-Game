using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public static PlayerManager Instance;

    public Action OnGameOver;
    
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _player.enabled = false;

        GameScreenManager.Instance.OnGameStarted += GameStarted;
    }
    
    private void GameStarted()
    {
        _player.enabled = true;
    }
    
    public void PlayerDied()
    {
        OnGameOver?.Invoke();
        _player.transform.position = new Vector3(0,0,0);
        _player.enabled = false;
    }
}

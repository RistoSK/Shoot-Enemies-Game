using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _padding = 0.7f;
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private bool _shouldBeControlled;
    
    [Header("Projectile")]
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private Transform _projectileSpawnTransform;
    
    [Header("Cooldown Bar")]
    [SerializeField] private Transform _cooldownBarTransform;
    [SerializeField] private GameObject _cooldownBar;
    
    public static PlayerController Instance;
    
    public Action OnGameOver;
    
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private IPlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;

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
        
        _playerInput = new PlayerInput();
        
        _playerMovement = new PlayerMovement(_playerInput, _playerStats, transform);
        _playerShooting = new PlayerShooting(_playerStats, _projectileSpawnTransform, _objectPool,
                                             _cooldownBar, _cooldownBarTransform);
    }

    private void Start()
    {
        GameRootController.Instance.OnGameStarted += GameStarted;
        
        _shouldBeControlled = false;
        
        _minX = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding;
        _maxX = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding;

        _minY = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding;
        _maxY = _camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding;
    }

    private void Update()
    {
        if (!_shouldBeControlled)
        {
            return;
        }
        
        _playerInput.GetInput();
        
        _playerMovement.Tick();
        _playerShooting.Tick();
        
        SetPlayerWithinBounds(transform.position);
    }

    private void SetShouldBeControlled(bool shouldMove)
    {
        _shouldBeControlled = shouldMove;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        
        if (enemy)
        {
            GameEnded();
        }
    }

    private void SetPlayerWithinBounds(Vector3 currentPosition)
    {
        float newPositionX = Mathf.Clamp(currentPosition.x, _minX, _maxX);
        float newPositionY = Mathf.Clamp(currentPosition.y, _minY, _maxY);

        currentPosition = new Vector2(newPositionX, newPositionY);
        transform.position = currentPosition;
    }
    
    private void GameStarted()
    {
        SetShouldBeControlled(true);
    }

    private void GameEnded()
    {
        OnGameOver?.Invoke();
        
        SetShouldBeControlled(false); 
        transform.position = new Vector3(0,0,0);
    }
}

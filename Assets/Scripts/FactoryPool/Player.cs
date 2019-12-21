using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float _padding = 0.7f;
    [SerializeField] private float _projectileSpeed = 20f;
    [SerializeField] private Camera _camera;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private Transform _projectileSpawnTransform;
    [SerializeField] private Transform _cooldownBarTransform;
    [SerializeField] private GameObject _cooldownBar;

    [SerializeField] private PlayerStats _playerStats;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private float _currentCooldown;

    private Rigidbody2D _rigidBody2D;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _currentCooldown = _playerStats.ShootingCooldown;

        _minX = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding;
        _maxX = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding;

        _minY = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding;
        _maxY = _camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        
        float newPositionX = Mathf.Clamp(currentPosition.x, _minX, _maxX);
        float newPositionY = Mathf.Clamp(currentPosition.y, _minY, _maxY);

        currentPosition = new Vector2(newPositionX, newPositionY);
        transform.position = currentPosition;

        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _playerStats.Speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _playerStats.Speed;

        _rigidBody2D.velocity = new Vector2(deltaX, deltaY);

        if (_currentCooldown > _playerStats.ShootingCooldown)
        {
            _cooldownBar.SetActive(false);
            
            if (Input.GetButtonDown("Fire1"))
            {
                var instance = _objectPool.GetPrefabInstance();
                var projectileTransform = instance.transform;
                
                projectileTransform.position = _projectileSpawnTransform.position;
                _currentCooldown = 0f;
                _cooldownBarTransform.localScale = new Vector3(1, 1, 0);
                _cooldownBar.SetActive(true);
                
                instance.GetComponent<Rigidbody2D>().AddForce(projectileTransform.rotation * (new Vector2(1, 0) * _projectileSpeed), ForceMode2D.Impulse);
            } 
        }
        else
        {
            _currentCooldown += Time.deltaTime;
            _cooldownBarTransform.localScale = new Vector3(1 -  (_currentCooldown / _playerStats.ShootingCooldown), 1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        
        if (enemy)
        {
            //_rigidBody2D.velocity = new Vector2(0,0);
            PlayerManager.Instance.PlayerDied();
        }
    }
}

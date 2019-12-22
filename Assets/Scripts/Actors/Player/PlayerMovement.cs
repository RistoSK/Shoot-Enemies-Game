using UnityEngine;

public class PlayerMovement
{
    private readonly IPlayerInput _playerInput;
    private readonly PlayerStats _playerStats;
    private readonly Transform _playerTransform;

    public PlayerMovement(IPlayerInput input, PlayerStats stats, Transform playerTransform)
    {
        _playerInput = input;
        _playerStats = stats;
        _playerTransform = playerTransform;
    }

    public void Tick()
    {
        _playerTransform.position += new Vector3(_playerInput.HorizontalMovement * _playerStats.Speed * Time.deltaTime,
                                                 _playerInput.VerticalMovement * _playerStats.Speed * Time.deltaTime,
                                                 0);
    }
}

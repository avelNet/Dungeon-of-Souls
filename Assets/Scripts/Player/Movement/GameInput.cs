using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions _playerInputAction;
    private Vector2 _inputMove;

    private void Awake()
    {
        Instance = this;

        _playerInputAction = new PlayerInputActions();
        _playerInputAction.Enable();
    }

    private void Update()
    {
        GetMoveDirection();
    }

    public Vector2 GetMoveDirection()
    {
        _inputMove = _playerInputAction.Player.Move.ReadValue<Vector2>();
        return _inputMove;
    }
}

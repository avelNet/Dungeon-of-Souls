using TMPro.EditorUtilities;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _boostSpeed = 10f;

    private float _minMovingSpeed = 0.1f;

    private bool _isRunning;
    private bool _isBoosting;

    private Rigidbody2D _rb;
    private Vector2 _inputMove;

    private void Awake()
    {
        Instance = this;

        _rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        _inputMove = GameInput.Instance.GetMoveDirection();

        if (Mathf.Abs(_inputMove.x) > _minMovingSpeed || Mathf.Abs(_inputMove.y) > _minMovingSpeed)
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
        _isBoosting = Stamina.Instance.IsBoosting();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speed = 0;
        if (_isBoosting)
        {
            speed = _boostSpeed;
        }
        else if(_isRunning)
        {
            speed = _moveSpeed;
        }
        _rb.MovePosition(_rb.position + _inputMove * (speed * Time.deltaTime));
    }

    public bool IsRunning()
    {
        return _isRunning;
    }
}

using TMPro.EditorUtilities;
using Unity.Jobs;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private PlayerSO _playerSo;
    [SerializeField] private float _moveSpeed = 5f;

    private float _minMovingSpeed = 0.1f;
    private float _boostSpeed = 10f;

    private bool _isRunning;
    private bool _isBoosting;

    private float staminaTimer;
    private float staminaTime = 2f;
    private int _stamina;
    private int _maxStamina = 5;
    private float _staminaRegenRate = 3f;
    private float _regenTimer;

    private Rigidbody2D _rb;
    private Vector2 _inputMove;

    private void Awake()
    {
        Instance = this;

        _rb = GetComponent<Rigidbody2D>();
        _stamina = _playerSo.stamina;
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

        staminaTimer += Time.deltaTime;
        StaminaCount();
        _isBoosting = 
            IsRunning() && 
            Input.GetKey(KeyCode.LeftShift) && 
            _stamina > 0;
    }

    private void StaminaCount()
    {
        if(_isBoosting)
        {
            if (staminaTimer >= staminaTime)
            {
                _stamina--;
                staminaTimer = 0f;
                if (_stamina <= 0)
                {
                    _stamina = 0;
                    Debug.Log("Стамина кончилась");
                    _isBoosting = false;
                }
            }
        } 
        else if (!_isBoosting)
        {
            _regenTimer += Time.deltaTime;
            if(_regenTimer >= _staminaRegenRate)
            {
                _isBoosting = false;
                _stamina++;
                
                _regenTimer = 0f;
            }
            
            if(_stamina >= _maxStamina)
            {
                _stamina = _maxStamina;
                Debug.Log("Стамина восстановилась");
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speed;

        if(_isBoosting)
        {
            speed = _boostSpeed;
        }
        else
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

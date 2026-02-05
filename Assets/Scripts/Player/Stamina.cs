using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public static Stamina Instance { get; private set; }

    [SerializeField] private PlayerSO _playerSo;
    [SerializeField] private float _staminaTime = 2f;

    private float _staminaTimer;
    private float _stamina;
    private float _maxStamina;

    private float _decreaseTimer;
    private float _decreaseTime = 10f; 

    private bool _isBoosting;
    private bool _staminaOnCooldown;

    private void Awake()
    {
        Instance = this;

        _maxStamina = _playerSo.stamina;
        _stamina = _playerSo.stamina;
        _isBoosting = true;
    }

    private void Update()
    {
        _isBoosting =
            Player.Instance.IsRunning() &&
            Input.GetKey(KeyCode.LeftShift) &&
            _stamina > 0;
        StaminaCount();
    }

    private void StaminaCount()
    {
        if(_isBoosting && !_staminaOnCooldown)
        {
            _staminaTimer += Time.deltaTime;

            if(_staminaTimer >= _staminaTime)
            {
                _stamina--;
                _staminaTimer = 0f;

                if(_stamina <= 0)
                {
                    _stamina = 0f;
                    _staminaOnCooldown = true;
                    Debug.Log("Стамина кончилась");
                }
            }
        } else if(_staminaOnCooldown)
        {
            _decreaseTimer += Time.deltaTime;

            if(_decreaseTimer >= _decreaseTime)
            {
                _stamina = _maxStamina;
                _staminaOnCooldown = false;
                _decreaseTimer = 0f;
                Debug.Log("Стамина восстановлена");
            }
        }
    }

    public bool IsBoosting()
    {
        return _isBoosting; 
    }
}

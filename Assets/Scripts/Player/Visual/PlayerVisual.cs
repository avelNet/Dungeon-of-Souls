using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _animator.SetBool("isRunning", Player.Instance.IsRunning());
    }

    private void FixedUpdate()
    {
        FlipXPlayer();
    }

    private void FlipXPlayer()
    {
        Vector2 direction = GameInput.Instance.GetMoveDirection();
        if(direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(direction.x < 0)
        {
            _spriteRenderer.flipX= true;
        }
    }

    private void Running()
    {
        if( _animator != null)
        {

        }
    }
}

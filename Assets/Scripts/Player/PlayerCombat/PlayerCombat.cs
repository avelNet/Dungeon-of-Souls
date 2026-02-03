using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator _animator;
    private bool _isRunning;
    private bool _isAttacking;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _isRunning = Player.Instance.IsRunning();
        Attack1();
    }

    private void Attack1()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(_isRunning || _isAttacking)
            {
                return;
            }

            _isAttacking = true;
            _animator.SetTrigger("Attack1");
            _animator.SetBool("isRunning", false);
        }
    }

    public void OnAttackEnd()
    {
        _isAttacking = false;
    }
}

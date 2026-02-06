using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemySO _enemySo;
    private Animator _animator;
    private float _currentHp;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _currentHp = _enemySo.maxHp;
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;

        if( _currentHp <= 0)
        {
            _currentHp = 0f;
            Die();
        }
    }

    public void Die()
    {
        //_animator.SetBool("Died", true);
        Debug.Log("Враг убит");
        Destroy(gameObject);
        RoomEvents.OnKilledEnemy?.Invoke(this);
    }
}

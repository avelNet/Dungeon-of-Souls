using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemySO _enemySo;
    [SerializeField] private EnemyHealth _enemy;
    private float _currentHp;
    private void Awake()
    {
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
        Debug.Log("Враг убит");
        RoomEvents.OnKilledEnemy?.Invoke(this);
        Destroy(gameObject);
    }
}

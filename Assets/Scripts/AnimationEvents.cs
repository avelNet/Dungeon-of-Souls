using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private PlayerCombat _playerCombat;

    private void Awake()
    {
        _playerCombat = GetComponentInParent<PlayerCombat>();
    }

    public void OnAttackEnd()
    {
        _playerCombat.OnAttackEnd();
    }
}

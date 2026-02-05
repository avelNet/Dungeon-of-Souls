using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int maxHp = 100;
    public int stamina = 5;
    public float shield = 50f;
}

using Unity.VisualScripting;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Room _room;
    private bool _isTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_isTriggered) { return; }
        if(other.CompareTag("Player"))
        {
            _isTriggered = true;
            RoomEvents.OnRoomEntered?.Invoke(_room);
        }
    }
}

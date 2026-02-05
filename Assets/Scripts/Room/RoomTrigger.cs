using Unity.VisualScripting;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Room _room;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            RoomEvents.OnRoomEntered?.Invoke(_room);
        }
    }
}

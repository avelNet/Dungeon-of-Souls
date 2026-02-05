using Assets.Scripts.Room;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Doors[] _doors;

    private void OnEnable()
    {
        RoomEvents.OnRoomEntered += OnRoomEntered;
    }

    private void OnDisable()
    {
        RoomEvents.OnRoomEntered -= OnRoomEntered;
    }

    private void OnRoomEntered(Room room)
    {
        if(room != this) { return; }
        CloseDoor();
    }

    private void CloseDoor()
    {
        foreach(var door in _doors)
        {
            door.Close();
        }
    }
}

using Assets.Scripts.Room;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Doors> _doors;
    [SerializeField] private List<EnemyHealth> _enemiesInRoom;

    private bool _roomActive;

    private void Awake()
    {
        _doors = new List<Doors>(GetComponentsInChildren<Doors>());
        _enemiesInRoom = new List<EnemyHealth>(GetComponentsInChildren<EnemyHealth>());

        Debug.Log($"Комната {name}: врагов найдено {_enemiesInRoom.Count}");
    }

    private void OnEnable()
    {
        RoomEvents.OnRoomEntered += OnRoomEntered;
        RoomEvents.OnKilledEnemy += OnEnemyKilled;
    }

    private void OnDisable()
    {
        RoomEvents.OnRoomEntered -= OnRoomEntered;
        RoomEvents.OnKilledEnemy -= OnEnemyKilled;
    }

    private void OnRoomEntered(Room room)
    {
        if(room != this) { return; }
        _roomActive = true;
        Debug.Log("Игрок вошёл в комнату");
        CloseDoor();
    }

    private void OnEnemyKilled(EnemyHealth enemy)
    {
        if(!_roomActive) { return; }

        if (_enemiesInRoom.Contains(enemy))
        {
            _enemiesInRoom.Remove(enemy);
            Debug.Log("Врагов осталось: " + _enemiesInRoom.Count);
        }
        if(_enemiesInRoom.Count == 0)
        {
            OpenDoor();
        }
    }

    private void CloseDoor()
    {
        foreach(var door in _doors)
        {
            door.Close();
        }
    }
    private void OpenDoor()
    {
        foreach(var door in _doors)
        {
            door.Open();
        }
    }
}

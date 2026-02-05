using UnityEngine;
using System;
using UnityEditor.PackageManager;

public class RoomEvents
{
    public static Action<Room> OnRoomEntered;
    public static Action<EnemyHealth> OnKilledEnemy;
}

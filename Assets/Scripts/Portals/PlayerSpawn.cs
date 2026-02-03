using Assets.Scripts.Core;
using Assets.Scripts.Portals;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance == null) { return; }
        string spawnId = GameManager.Instance.NextSpawnID;
        SpawnPoint spawn = SpawnPoint.FindById(spawnId);

        if(spawn != null )
        {
            transform.position = spawn.transform.position;
        }
    }
}

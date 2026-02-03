using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Portals
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private string _spawnID;
        public string getSpawnID
        {
            get
            {
                return _spawnID;
            }
        }

        public static SpawnPoint FindById(string spawnId)
        {
            var points = Object.FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);
            foreach (var point in points)
            {
                if(point._spawnID == spawnId)
                {
                    return point;
                }
            }
            return null;
        }
    }
}
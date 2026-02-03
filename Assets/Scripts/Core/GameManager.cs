using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.Scripts.Portals;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public string NextSpawnID;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Transform player = null;

            if (string.IsNullOrEmpty(NextSpawnID)) { return; }

            var spawn = SpawnPoint.FindById(NextSpawnID);
            if (spawn == null)
            {
                Debug.Log("Spawn is not defined");
                return;
            }
            
            if (Player.Instance != null)
            {
                player = Player.Instance.transform; 
            }
            else
            {
                GameObject playerObj = GameObject.FindWithTag("Player");
                if(playerObj != null)
                {
                    player = playerObj.transform;
                }
            }
            if( player == null) 
            {
                Debug.Log("Player is null");
                return; 
            }
            player.position = spawn.transform.position;
        }
    }
}
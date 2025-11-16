using Unity.Netcode;
using UnityEngine;

namespace K02.Network
{
    public class NetworkPlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerPrefab;

        private void Start()
        {
            if (NetworkManager.Singleton == null)
                Debug.LogError("NetworkManager is not found in the scene.");

            //NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
        }

        private void OnDestroy()
        {
            //if(NetworkManager.Singleton != null)
                //NetworkManager.Singleton.OnClientConnectedCallback -= SpawnPlayer;
        }

        private void SpawnPlayer(ulong clientId)
        {
            // Only the server should spawn players
            if (!NetworkManager.Singleton.IsServer)
                return;

            // Choose a spawn point (example: middle of the map)
            Vector3 spawnPos = new Vector3(
                Random.Range(-3f, 3f),
                0,
                Random.Range(-3f, 3f)
            );

            // Instantiate and spawn
            var playerObj = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
            playerObj.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
        }
    }
}
using K02.Core;
using Unity.Netcode;
using UnityEngine;

namespace K02.Networking
{
    public class NetworkBootstrap : MonoBehaviour
    {
        public bool offlineMode = false;

        void Start()
        {
            if (offlineMode)
            {
                OfflineMode.StartOfflineSession();
            }
            else
            {
                // When network starts hosting, spawn the GameManager
                NetworkManager.Singleton.OnServerStarted += OnServerStarted;
            }
        }

        private void OnServerStarted()
        {
            if (!NetworkManager.Singleton.IsHost)
                return;

            // Load GameManager prefab from Resources
            GameManager prefab = Resources.Load<GameManager>("GameManager");

            // Instantiate and spawn
            var gm = Instantiate(prefab);
            gm.GetComponent<NetworkObject>().Spawn(true);

            Debug.Log("GameManager spawned by Host.");
        }
    }

}
using K02.Core;
using UnityEngine;

namespace K02.Networking
{
    public static class OfflineMode
    {
        public static bool IsOffline => _isOffline;
        private static bool _isOffline;

        public static void StartOfflineSession()
        {
            _isOffline = true;

            // Create GameManager manually
            var prefab = Resources.Load<GameManager>("GameManager");
            var gm = GameObject.Instantiate(prefab);
            gm.InitializeOffline();
        }
    }
}
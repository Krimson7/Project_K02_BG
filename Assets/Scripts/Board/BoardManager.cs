using K02.Networking;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace K02.Board
{
    public class BoardManager : NetworkBehaviour
    {
        public List<Transform> Tiles;         // Drag 40 tiles from hierarchy
        public GameObject PlayerPiecePrefab;  // Prefab with NetworkObject

        private Dictionary<ulong, PlayerPiece> pieces = new();

        public void SpawnPieceForPlayer(ulong playerId)
        {
            var obj = Instantiate(PlayerPiecePrefab);
            var net = obj.GetComponent<NetworkObject>();

            if (!OfflineMode.IsOffline)
                net.SpawnWithOwnership(playerId);

            pieces[playerId] = obj.GetComponent<PlayerPiece>();
            pieces[playerId].SetPosition(Tiles[0].position);
        }

        public void MovePiece(ulong playerId, int tileIndex)
        {
            pieces[playerId].SetPosition(Tiles[tileIndex].position);
        }

        public int GetNextTile(int current, int steps)
        {
            return (current + steps) % Tiles.Count;
        }
    }
}
using K02.Board;
using K02.Networking;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


namespace K02.Core
{
    public class GameManager : NetworkBehaviour
    {
        public static GameManager Instance;

        public List<PlayerData> Players = new();

        private TurnSystem TurnSystem;
        private BoardManager Board;

        void Awake()
        {
            Instance = this;
        }

        public override void OnNetworkSpawn()
        {
            if (OfflineMode.IsOffline)
                return;

            Debug.Log("GameManager OnNetworkSpawn Online");

            if (IsServer)
            {
                InitializeOnline();
            }
        }

        public void InitializeOffline()
        {
            Board = FindObjectOfType<BoardManager>();

            // Create 1 local player for offline
            Players.Add(new PlayerData(0, "Player"));
            Board.SpawnPieceForPlayer(0);

            TurnSystem = new TurnSystem();
            TurnSystem.StartTurns();
        }

        public void InitializeOnline()
        {
            Board = FindObjectOfType<BoardManager>();

            foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
            {
                var id = client.ClientId;
                Players.Add(new PlayerData(id, $"Player {id}"));
                Board.SpawnPieceForPlayer(id);
            }

            TurnSystem = new TurnSystem();
            TurnSystem.StartTurns();
        }

        // Called by UI when player presses "Roll"
        [ServerRpc(RequireOwnership = false)]
        public void RollDiceServerRpc(ulong playerId)
        {
            if (!TurnSystem.IsPlayerTurn(playerId))
                return;

            int roll = Random.Range(1, 7) + Random.Range(1, 7);

            MovePlayer(playerId, roll);
            TurnSystem.EndTurn();
        }

        private void MovePlayer(ulong playerId, int steps)
        {
            PlayerData pd = Players.Find(x => x.PlayerId == playerId);
            pd.TileIndex = Board.GetNextTile(pd.TileIndex, steps);

            Board.MovePiece(playerId, pd.TileIndex);
        }
    }
}

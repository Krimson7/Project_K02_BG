using Unity.Netcode;
using UnityEngine;

namespace K02.Board.Dice
{
    public class DiceController : NetworkBehaviour
    {
        public DiceSystem System { get; private set; }
        public System.Action<int> OnDiceRolled; // Event for UI / movement systems

        private void Awake()
        {
            System = new DiceSystem();
        }

        [ServerRpc(RequireOwnership = false)]
        public void RequestDiceRollServerRpc()
        {
            int value = System.Roll();
            SendDiceResultClientRpc(value);
        }

        [ClientRpc]
        private void SendDiceResultClientRpc(int value)
        {
            // Fire event to listeners (UIAdapter, TurnSystem, etc)
            OnDiceRolled?.Invoke(value);
        }
    }
}
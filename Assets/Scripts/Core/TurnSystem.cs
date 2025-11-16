namespace K02.Core
{
    public class TurnSystem
    {
        private int turnIndex = 0;

        public void StartTurns()
        {
            turnIndex = 0;
        }

        public bool IsPlayerTurn(ulong playerId)
        {
            return GameManager.Instance.Players[turnIndex].PlayerId == playerId;
        }

        public void EndTurn()
        {
            turnIndex = (turnIndex + 1) % GameManager.Instance.Players.Count;
        }
    }
}
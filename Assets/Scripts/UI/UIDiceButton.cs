using K02.Board.Dice;
using UnityEngine;

namespace K02.UI.Dice
{
    public class DiceUIButton : MonoBehaviour
    {
        private DiceController controller;

        public void Init(DiceController controller)
        {
            this.controller = controller;
        }

        public void OnRollPressed()
        {
            controller.RequestDiceRollServerRpc();
        }
    }
}
using K02.Board.Dice;
using UnityEngine;

namespace K02.UI.Dice
{
    public class UIDiceVisualizer : MonoBehaviour
    {
        [SerializeField] 
        private UIDiceText diceUI;

        [SerializeField]
        private DiceUIButton diceUIButton;

        DiceController controller;

        public void Init(DiceController controller)
        {
            this.controller = controller;
            diceUIButton.Init(controller);
            controller.OnDiceRolled += HandleDiceRolled;
        }

        void HandleDiceRolled(int value)
        {
            diceUI.Display(value);
        }
    }
}
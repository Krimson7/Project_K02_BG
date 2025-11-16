using UnityEngine;

namespace K02.Board.Dice
{
    public class DiceSystem
    {
        public int Roll()
        {
            return Random.Range(1, 7);
        }
    }
}
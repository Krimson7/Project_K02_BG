using K02.Player.Combat;
using K02.Player.Movement;
using UnityEngine;

namespace K02.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement Movement;

        [SerializeField]
        private PlayerAnimation Animation;

        [SerializeField]
        private PlayerCombat Combat;

        public void SetMoveDirection(Vector2 direction)
        {
            Movement.SetMoveDirection(direction);
        }

        public void Attack()
        {
            //Combat.Attack();
        }

        public void PlayAnimation(string animationName)
        {
            //Animation.Play(animationName);
        }
    }
}

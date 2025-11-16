using Unity.Netcode;
using UnityEngine;

namespace K02.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5f;

        private Vector2 _currentDirection = Vector2.zero;

        // Called by PlayerController/InputHandler
        public void SetMoveDirection(Vector2 direction)
        {
            _currentDirection = direction;
        }

        private void FixedUpdate()
        {
            // Only move if this is the local player
            if (IsOwner && _currentDirection != Vector2.zero)
            {
                Vector3 move = new Vector3(_currentDirection.x, _currentDirection.y, 0) * moveSpeed * Time.fixedDeltaTime;
                transform.position += move;
                // NetworkTransform will sync this position to other clients
            }
        }
    }
}
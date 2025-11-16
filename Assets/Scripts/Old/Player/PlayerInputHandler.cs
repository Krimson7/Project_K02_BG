using UnityEngine;
using UnityEngine.InputSystem;

namespace K02.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerController;

        [SerializeField]
        private InputActionAsset _inputActions;

        private InputAction _moveAction;
        private InputAction _attackAction;

        private void OnEnable()
        {
            _moveAction = _inputActions.FindAction("Movement");
            _attackAction = _inputActions.FindAction("Attack/Break");

            _moveAction.Enable();
            _attackAction.Enable();

            _moveAction.performed += OnMove;
            _attackAction.performed += OnAttack;
        }

        private void OnDisable()
        {
            _moveAction.performed -= OnMove;
            _attackAction.performed -= OnAttack;

            _moveAction.Disable();
            _attackAction.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            _playerController.SetMoveDirection(direction);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
                _playerController.Attack();
        }
    }
}
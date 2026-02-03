using Panda.Adventure.InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Panda.Adventure
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 3f;
        public float rotationSpeed = 8f;

        public InputActionReference movementAction;
        public InputActionReference interactAction;

        private Animator _animator;
        private CharacterController _characterController;
        private Interactor _interactor;

        private Vector3 _currentMovement;
        private bool _isTryingToMove;

        private int _isWalkingHash;
        private int _interactHash;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _interactor = GetComponent<Interactor>();
        }

        private void Start()
        {
            _isWalkingHash = Animator.StringToHash("IsWalking");
            _interactHash = Animator.StringToHash("Interact");

            movementAction.action.performed += OnMovementInput;
            movementAction.action.started += OnMovementInput;
            movementAction.action.canceled += OnMovementInput;

            interactAction.action.started += OnInteractInput;
        }

        private void Update()
        {
            HandleGravity();
            HandleRotation();
            HandleAnimation();

            _characterController.Move(_currentMovement * Time.deltaTime);
        }

        private void OnMovementInput(InputAction.CallbackContext context)
        {
            var currentMovementInput = context.ReadValue<Vector2>();
            _currentMovement.x = currentMovementInput.x * moveSpeed;
            _currentMovement.z = currentMovementInput.y * moveSpeed;
            _isTryingToMove = currentMovementInput != Vector2.zero;
        }

        private void HandleAnimation()
        {
            var isWalking = _animator.GetBool(_isWalkingHash);

            if (_isTryingToMove && !isWalking) _animator.SetBool(_isWalkingHash, true);
            else if (!_isTryingToMove && isWalking) _animator.SetBool(_isWalkingHash, false);
        }

        private void HandleRotation()
        {
            var positionToLookAt = Vector3.zero;
            positionToLookAt.x = _currentMovement.x;
            positionToLookAt.z = _currentMovement.z;

            var currentRotation = transform.rotation;

            if (_isTryingToMove)
            {
                var targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        private void HandleGravity()
        {
            if (_characterController.isGrounded)
                _currentMovement.y = -0.5f;
            else
                _currentMovement.y += -9.8f;
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !_isTryingToMove && _interactor.focused != null)
            {
                _animator.SetTrigger(_interactHash);
                _interactor.focused.Interact();
            }
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Panda
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject, GameInput.IAdventureActions, GameInput.IDialogueActions
    {
        // Adventure
        public event Action<Vector2> moveEvent;
        public event Action interactEvent;

        // Dialogue
        public event Action advanceDialogueEvent;

        private GameInput _gameInput;

        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Adventure.SetCallbacks(this);
                _gameInput.Dialogue.SetCallbacks(this);
            }

            DisableAllInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                interactEvent?.Invoke();
        }

        public void OnAdvanceDialogue(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                advanceDialogueEvent?.Invoke();
        }

        public void EnableAdventureInput()
        {
            _gameInput.Adventure.Enable();
            _gameInput.Dialogue.Disable();
        }

        public void EnableDialogueInput()
        {
            _gameInput.Dialogue.Enable();
            _gameInput.Adventure.Disable();
        }

        public void DisableAllInput()
        {
            _gameInput.Adventure.Disable();
            _gameInput.Dialogue.Disable();
        }
    }
}
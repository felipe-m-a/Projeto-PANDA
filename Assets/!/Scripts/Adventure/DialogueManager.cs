using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Panda.Adventure
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera cinemachine;
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_Text textMesh;
        [SerializeField] private InputActionReference advanceAction;

        private InteractionSystem.Dialogue _dialogue;
        private int _lineIndex;

        public void StartDialogue(InteractionSystem.Dialogue dialogue)
        {
            EventBus.RaiseDialogueStartEvent();
            cinemachine.Target.TrackingTarget = dialogue.Target;
            cinemachine.Priority = 10;
            canvas.enabled = true;

            _dialogue = dialogue;
            AdvanceDialogue();
        }

        private void EndDialogue()
        {
            cinemachine.Priority = -10;
            canvas.enabled = false;
            _lineIndex = 0;
            EventBus.RaiseDialogueEndEvent();
        }

        public void AdvanceDialogue()
        {
            if (_dialogue.Lines.Count > _lineIndex)
            {
                textMesh.text = _dialogue.Lines[_lineIndex];
                _lineIndex++;
            }
            else
            {
                EndDialogue();
            }
        }

        private void OnEnable()
        {
            canvas.enabled = false;
            advanceAction.action.started += OnAdvanceInput;
        }

        private void OnDisable()
        {
            advanceAction.action.started -= OnAdvanceInput;
        }

        private void OnAdvanceInput(InputAction.CallbackContext context)
        {
            AdvanceDialogue();
        }
    }
}
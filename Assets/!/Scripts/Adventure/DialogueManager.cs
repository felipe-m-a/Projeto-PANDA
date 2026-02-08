using Panda.Adventure.InteractionSystem;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

namespace Panda.Adventure
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera cinemachine;
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_Text textMesh;
        [SerializeField] private InputReader inputReader;

        private Dialogue _dialogue;
        private int _lineIndex;

        public void StartDialogue(Dialogue dialogue)
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
            inputReader.advanceDialogueEvent += AdvanceDialogue;
        }

        private void OnDisable()
        {
            inputReader.advanceDialogueEvent += AdvanceDialogue;
        }
    }
}
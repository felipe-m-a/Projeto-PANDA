using UnityEngine;

namespace Panda.Adventure
{
    [RequireComponent(typeof(Canvas))]
    public class OnScreenControlsManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private Canvas _canvas;

        private void OnEnable()
        {
            _canvas = GetComponent<Canvas>();

            _canvas.enabled = gameManager.isOnScreenControlsOn;

            EventBus.DialogueStarted += HandleDialogueStarted;
            EventBus.DialogueEnded += HandleDialogueEnded;

            EventBus.MinigameStarted += HandleMinigameStarted;
            EventBus.MinigameEnded += HandleMinigameEnded;
        }


        private void OnDisable()
        {
            EventBus.DialogueStarted -= HandleDialogueStarted;
            EventBus.DialogueEnded -= HandleDialogueEnded;

            EventBus.MinigameStarted -= HandleMinigameStarted;
            EventBus.MinigameEnded -= HandleMinigameEnded;
        }

        private void HandleDialogueStarted()
        {
            _canvas.enabled = false;
        }

        private void HandleDialogueEnded()
        {
            _canvas.enabled = gameManager.isOnScreenControlsOn;
        }

        private void HandleMinigameStarted()
        {
            _canvas.enabled = false;
        }

        private void HandleMinigameEnded()
        {
            _canvas.enabled = gameManager.isOnScreenControlsOn;
        }
    }
}
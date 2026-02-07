using UnityEngine;

namespace Panda.Adventure
{
    [RequireComponent(typeof(Canvas))]
    public class OnScreenControlsManager : MonoBehaviour
    {
        private Canvas _canvas;
        private bool _isShowingControls;

        private void OnEnable()
        {
            _canvas = GetComponent<Canvas>();

            _isShowingControls = Application.isMobilePlatform || Application.isEditor;
            _canvas.enabled = _isShowingControls;

            EventBus.OnDialogueStartEventRaised += HandleDialogueStartEvent;
            EventBus.OnDialogueEndEventRaised += HandleDialogueEndEvent;
        }

        private void OnDisable()
        {
            EventBus.OnDialogueStartEventRaised -= HandleDialogueStartEvent;
            EventBus.OnDialogueEndEventRaised -= HandleDialogueEndEvent;
        }

        private void HandleDialogueStartEvent()
        {
            _canvas.enabled = false;
        }

        private void HandleDialogueEndEvent()
        {
            _canvas.enabled = _isShowingControls;
        }
    }
}
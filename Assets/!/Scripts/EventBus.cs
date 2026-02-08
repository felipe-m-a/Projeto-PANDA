using System;

namespace Panda
{
    public static class EventBus
    {
        public static event Action OnDialogueStartEventRaised;
        public static event Action OnDialogueEndEventRaised;

        public static void RaiseDialogueStartEvent()
        {
            OnDialogueStartEventRaised?.Invoke();
        }

        public static void RaiseDialogueEndEvent()
        {
            OnDialogueEndEventRaised?.Invoke();
        }
    }
}
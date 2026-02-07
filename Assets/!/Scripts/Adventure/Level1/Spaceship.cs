using Panda.Adventure.InteractionSystem;
using UnityEngine;

namespace Panda.Adventure.Level1
{
    public class Spaceship : MonoBehaviour, IInteractable
    {
        [SerializeField] private Renderer interactableFocusIcon;
        [SerializeField] private DialogueManager dialogueManager;

        public bool CanInteract()
        {
            return true;
        }

        public void GainFocus()
        {
            interactableFocusIcon.enabled = true;
        }

        public void LoseFocus()
        {
            interactableFocusIcon.enabled = false;
        }

        public void Interact()
        {
            var dialogue = new Dialogue(transform);
            dialogue.AddLine("Sua nave está quebrada! Você precisa de peças para consertá-la.");
            dialogueManager.StartDialogue(dialogue);
        }
    }
}
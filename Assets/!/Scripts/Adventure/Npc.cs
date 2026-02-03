using System;
using Panda.Adventure.InteractionSystem;
using UnityEngine;

namespace Panda.Adventure
{
    public class Npc : MonoBehaviour, IInteractable
    {
        public Renderer interactableFocusIcon;

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
        }
    }
}
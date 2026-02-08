using Panda.Adventure.InteractionSystem;
using UnityEngine;

namespace Panda.Adventure.Level1
{
    public class Npc : MonoBehaviour, IInteractable
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
            dialogue.AddLine("Olá! Minha nave está quebrada e preciso de peças para consertá-la.", "Jogador");
            dialogue.AddLine("Ah, eu posso ajudar com isso! Mas antes, você poderia fazer algo por mim?", "Oobi");
            dialogue.AddLine("O que você precisa?", "Jogador");
            dialogue.AddLine("Eu preciso de 3 moedas. Você poderia coletá-las para mim?", "Oobi");
            dialogue.AddLine("Certo! Vou buscar as moedas. Onde eu posso encontrá-las?", "Jogador");
            dialogue.AddLine(
                "Você pode procurar na floresta ao norte. Existem alguns lugares onde as moedas costumam aparecer.",
                "Oobi");
            dialogue.AddLine("Assim que coletá-las, volte aqui!", "Oobi");
            dialogue.AddLine("Pode deixar! Vou lá agora mesmo.", "Jogador");
            dialogue.AddLine("Estou contando com você! Boa sorte!", "Oobi");
            dialogueManager.StartDialogue(dialogue);
        }
    }
}
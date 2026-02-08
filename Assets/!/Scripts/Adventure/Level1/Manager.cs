using UnityEngine;

namespace Panda.Adventure.Level1
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private DialogueManager dialogueManager;

        private void OnEnable()
        {
            // Para poder testar
            if (Application.isEditor) gameManager.inputReader.EnableAdventureInput();
        }
    }
}
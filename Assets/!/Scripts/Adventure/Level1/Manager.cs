using UnityEngine;

namespace Panda.Adventure.Level1
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private InputReader inputReader;

        private void OnEnable()
        {
            inputReader.EnableAdventureInput();

            EventBus.MinigameTriggered += HandleMinigameTriggered;
            EventBus.MinigameEnded += HandleMinigameEnded;
        }

        private void HandleMinigameTriggered(string scene)
        {
            inputReader.DisableAllInput();
            StartCoroutine(gameManager.LoadMinigameRoutine(scene, true));
        }

        private void HandleMinigameEnded()
        {
            inputReader.EnableAdventureInput();
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Panda
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/GameManager")]
    public class GameManager : ScriptableObject
    {
        public InputReader inputReader;

        public void LoadAdventureLevel(string scene)
        {
            SceneManager.LoadScene(scene);
            inputReader.EnableAdventureInput();
        }

        private void OnEnable()
        {
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
            inputReader.EnableDialogueInput();
        }

        private void HandleDialogueEndEvent()
        {
            inputReader.EnableAdventureInput();
        }


        public static class Scenes
        {
            public const string MainMenu = "MainMenu";

            public static class Adventure
            {
                public const string Level1 = "Level_1";
            }

            public static class Minigames
            {
                public const string Memory = "Memory";
            }
        }
    }
}
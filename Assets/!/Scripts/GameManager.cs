using System;
using Panda.Adventure.InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Panda
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/GameManager")]
    public class GameManager : ScriptableObject
    {
        [SerializeField] private InputActionAsset gameplayActionMap;

        public void LoadAdventureLevel(string scene)
        {
            SceneManager.LoadScene(scene);
            gameplayActionMap.FindActionMap("Adventure").Enable();
        }

        private void OnEnable()
        {
            EventBus.OnDialogueStartEventRaised += HandleDialogueStartEvent;
            EventBus.OnDialogueEndEventRaised += HandleDialogueEndEvent;
            
            gameplayActionMap.FindActionMap("Dialogue").Disable();
        }

        private void OnDisable()
        {
            EventBus.OnDialogueStartEventRaised -= HandleDialogueStartEvent;
            EventBus.OnDialogueEndEventRaised -= HandleDialogueEndEvent;
        }

        private void HandleDialogueStartEvent()
        {
            gameplayActionMap.FindActionMap("Adventure").Disable();
            gameplayActionMap.FindActionMap("Dialogue").Enable();
        }

        private void HandleDialogueEndEvent()
        {
            gameplayActionMap.FindActionMap("Adventure").Enable();
            gameplayActionMap.FindActionMap("Dialogue").Disable();
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
using System.Collections;
using System.Collections.Generic;
using Panda.Minigames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Panda
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/GameManager")]
    public class GameManager : ScriptableObject
    {
        public bool isOnScreenControlsOn = true;
        [Range(0, 2)] public int difficultyIndex = 1;
        [SerializeField] private List<Settings> minigamesSettingsList;


        public Settings SelectedMinigamesSettings => minigamesSettingsList[difficultyIndex];

        public IEnumerator LoadAdventureLevel(string scene)
        {
            yield return SceneManager.LoadSceneAsync(scene);
        }

        public IEnumerator LoadMinigameRoutine(string scene, bool onTop)
        {
            yield return SceneManager.LoadSceneAsync(scene, onTop ? LoadSceneMode.Additive : LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
        }

        public IEnumerator LoadMainMenuRoutine()
        {
            yield return SceneManager.LoadSceneAsync(Scenes.MainMenu);
        }

        public IEnumerator UnloadCurrentSceneRoutine()
        {
            var currentScene = SceneManager.GetActiveScene();
            yield return SceneManager.UnloadSceneAsync(currentScene);
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
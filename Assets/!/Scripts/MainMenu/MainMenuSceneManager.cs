using UnityEngine;

namespace Panda.MainMenu
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        public SceneStackManager sceneStackManager;

        public void AdventureButtonAction()
        {
            StartCoroutine(sceneStackManager.GotoSceneRoutine(Scenes.Adventure.Level1));
        }
    }
}
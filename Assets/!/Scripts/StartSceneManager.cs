using UnityEngine;

namespace Panda
{
    public class StartSceneManager : MonoBehaviour
    {
        public SceneStackManager sceneStackManager;

        private void Start()
        {
            StartCoroutine(sceneStackManager.GotoSceneRoutine(Scenes.MainMenu));
        }
    }
}
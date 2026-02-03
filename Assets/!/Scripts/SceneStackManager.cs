using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Panda
{
    [CreateAssetMenu(fileName = "SceneStackManager", menuName = "Scriptable Objects/SceneStackManager")]
    public class SceneStackManager : ScriptableObject
    {
        private readonly Stack<Scenes.Data> _sceneStack = new Stack<Scenes.Data>();
        private readonly Dictionary<Scenes.Data, Scene> _loadedScenes = new Dictionary<Scenes.Data, Scene>();

        public IEnumerator PushSceneRoutine(Scenes.Data sceneData)
        {
            yield return LoadSceneRoutine(sceneData);
            yield return SetActiveSceneRoutine(sceneData);
            _sceneStack.Push(sceneData);
        }

        public IEnumerator PopSceneRoutine()
        {
            var current = _sceneStack.Pop();
            if (_sceneStack.Count > 0)
            {
                yield return SetActiveSceneRoutine(_sceneStack.Peek());
            }
            yield return UnloadSceneRoutine(current);
        }

        public IEnumerator GotoSceneRoutine(Scenes.Data sceneData)
        {
            yield return LoadSceneRoutine(sceneData);
            yield return SetActiveSceneRoutine(sceneData);
            while (_sceneStack.Count > 0)
            {
                yield return UnloadSceneRoutine(_sceneStack.Pop());
            }

            _sceneStack.Push(sceneData);
        }

        private IEnumerator LoadSceneRoutine(Scenes.Data sceneData)
        {
            var loadOperation = SceneManager.LoadSceneAsync(sceneData.Name, LoadSceneMode.Additive);
            yield return loadOperation;
            var loadedScene = SceneManager.GetSceneByName(sceneData.Name);
            if (loadedScene.IsValid() && loadedScene.isLoaded)
            {
                _loadedScenes.Add(sceneData, loadedScene);
            }
            else
            {
                Debug.LogError("Loaded scene is invalid or not found.");
            }
        }

        private IEnumerator SetActiveSceneRoutine(Scenes.Data sceneData)
        {
            var loadedScene = _loadedScenes[sceneData];
            SceneManager.SetActiveScene(loadedScene);
            // TODO: Set input map
            yield break;
        }

        private IEnumerator UnloadSceneRoutine(Scenes.Data sceneData)
        {
            var unloadOperation = SceneManager.UnloadSceneAsync(sceneData.Name);
            yield return unloadOperation;
            _loadedScenes.Remove(sceneData);
        }

        private IEnumerator CleanUnusedAssetsRoutine()
        {
            var cleanupOperation = Resources.UnloadUnusedAssets();
            yield return cleanupOperation;
        }
    }
}
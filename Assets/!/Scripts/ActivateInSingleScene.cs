using UnityEngine;
using UnityEngine.SceneManagement;

namespace Panda
{
    public class ActivateInSingleScene : MonoBehaviour
    {
        [SerializeField] private GameObject[] objects;

        private void Start()
        {
            if (SceneManager.loadedSceneCount == 1)
                foreach (var obj in objects)
                    obj.SetActive(true);
        }
    }
}
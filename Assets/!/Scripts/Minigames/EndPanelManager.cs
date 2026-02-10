using UnityEngine;
using UnityEngine.SceneManagement;

namespace Panda.Minigames
{
    public class EndPanelManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private Canvas _canvas;

        private void OnEnable()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
        }

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void ContinueButtonAction()
        {
            if (SceneManager.loadedSceneCount > 1)
                StartCoroutine(gameManager.UnloadCurrentSceneRoutine());
            else
                StartCoroutine(gameManager.LoadMainMenuRoutine());

            EventBus.RaiseMinigameEnded();
        }
    }
}
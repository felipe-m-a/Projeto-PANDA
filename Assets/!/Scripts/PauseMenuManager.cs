using UnityEngine;

namespace Panda
{
    [RequireComponent(typeof(Canvas))]
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private Canvas _canvas;

        private void OnEnable()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
        }

        public void Pause()
        {
            Time.timeScale = 0;
            _canvas.enabled = true;
        }

        public void ResumeButtonAction()
        {
            Time.timeScale = 1;
            _canvas.enabled = false;
        }

        public void QuitButtonAction()
        {
            Time.timeScale = 1;
            StartCoroutine(gameManager.LoadMainMenuRoutine());
        }
    }
}
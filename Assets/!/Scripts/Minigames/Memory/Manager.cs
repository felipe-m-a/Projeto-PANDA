using UnityEngine;

namespace Panda.Minigames.Memory
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        [SerializeField] private Board board;
        [SerializeField] private PauseMenuManager pauseMenuManager;
        [SerializeField] private EndPanelManager endPanelManager;

        private Minigame _minigame;

        private void Start()
        {
            var settings = gameManager.SelectedMinigamesSettings.memoryGame;
            _minigame = Minigame.Generate(settings.rows, settings.columns);
            board.Initialize(_minigame);
            EventBus.RaiseMinigameStarted();
        }

        private void Update()
        {
            if (_minigame.IsSolved()) endPanelManager.Show();
        }

        public void PauseButtonAction()
        {
            pauseMenuManager.Pause();
        }
    }
}
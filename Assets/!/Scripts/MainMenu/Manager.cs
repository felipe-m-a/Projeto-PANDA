using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Panda.MainMenu
{
    public class Manager : MonoBehaviour
    {
        public GameManager gameManager;

        [SerializeField] private CanvasGroup landingPage;
        [SerializeField] private CanvasGroup minigamesPage;
        [SerializeField] private CanvasGroup settingsPage;

        [SerializeField] private Toggle settingsOnScreenControlsToggle;
        [SerializeField] private TMP_Dropdown settingsDifficultyDropdown;

        private void Start()
        {
            settingsOnScreenControlsToggle.isOn = gameManager.isOnScreenControlsOn;
            settingsDifficultyDropdown.value = gameManager.difficultyIndex;
        }

        public void AdventureButtonAction()
        {
            StartCoroutine(gameManager.LoadAdventureLevel(GameManager.Scenes.Adventure.Level1));
        }

        public void MinigamesButtonAction()
        {
            landingPage.alpha = 0f;
            landingPage.interactable = false;
            landingPage.blocksRaycasts = false;

            minigamesPage.alpha = 1f;
            minigamesPage.interactable = true;
            minigamesPage.blocksRaycasts = true;
        }

        public void SettingsButtonAction()
        {
            landingPage.alpha = 0f;
            landingPage.interactable = false;
            landingPage.blocksRaycasts = false;

            settingsPage.alpha = 1f;
            settingsPage.interactable = true;
            settingsPage.blocksRaycasts = true;
        }

        public void BackButtonAction()
        {
            minigamesPage.alpha = 0f;
            minigamesPage.interactable = false;
            minigamesPage.blocksRaycasts = false;

            settingsPage.alpha = 0f;
            settingsPage.interactable = false;
            settingsPage.blocksRaycasts = false;

            landingPage.alpha = 1f;
            landingPage.interactable = true;
            landingPage.blocksRaycasts = true;
        }

        public void MinigamesMemoryButtonAction()
        {
            StartCoroutine(gameManager.LoadMinigameRoutine(GameManager.Scenes.Minigames.Memory, false));
        }

        public void MinigamesSlidePuzzleButtonAction()
        {
        }

        public void MinigamesFlowButtonAction()
        {
        }

        public void MinigamesPipesButtonAction()
        {
        }

        public void MinigamesSpaceshipButtonAction()
        {
        }

        public void MinigamesTBDButtonAction()
        {
        }

        public void SettingsOnScreenControlsToggleAction(bool changed)
        {
            if (changed)
                gameManager.isOnScreenControlsOn = !gameManager.isOnScreenControlsOn;
        }

        public void SettingsDifficultyDropdownAction(int changed)
        {
            if (changed == 1) gameManager.difficultyIndex = settingsDifficultyDropdown.value;
        }
    }
}
using UnityEngine;

namespace Panda.MainMenu
{
    public class Manager : MonoBehaviour
    {
        public GameManager gameManager;

        public void AdventureButtonAction()
        {
            gameManager.LoadAdventureLevel(GameManager.Scenes.Adventure.Level1);
        }

        public void DisableAdventureInputActions()
        {
        }

        public void EnableAdventureInputActions()
        {
        }
    }
}
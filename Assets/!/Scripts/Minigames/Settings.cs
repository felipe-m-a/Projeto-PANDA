using UnityEngine;
using UnityEngine.Assertions;

namespace Panda.Minigames
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Minigames/Settings")]
    public class Settings : ScriptableObject
    {
        public Memory.Settings memoryGame;

        private void OnValidate()
        {
            Assert.IsTrue(memoryGame.rows * memoryGame.columns % 2 == 0,
                "Minigame Memory: A quantidade de cartas tem que ser par");
        }
    }
}
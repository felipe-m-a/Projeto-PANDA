using UnityEngine;

namespace Panda.Adventure.Level1
{
    public class Coin : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                // levelData.collectedCoins.Add(_id);
                gameObject.SetActive(false);
            }
        }
    }
}
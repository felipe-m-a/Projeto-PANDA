using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Panda.Minigames.Memory
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private float flipDuration = 0.3f;

        private Button _button;
        private Board _board;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void Initialize(Sprite sprite, Board board)
        {
            icon.sprite = sprite;
            _board = board;
        }

        public void OnClick()
        {
            StartCoroutine(_board.SelectCard(this));
        }

        public bool IsInteractable
        {
            get => _button.interactable;
            set => _button.interactable = value;
        }

        public bool Matches(Card other)
        {
            return icon.sprite == other.icon.sprite;
        }

        public IEnumerator Show()
        {
            yield return Utils.RotateTo(transform, Quaternion.Euler(0f, 90f, 0f), flipDuration / 2f);
            icon.color = Color.white;
            yield return Utils.RotateTo(transform, Quaternion.Euler(0f, 180f, 0f), flipDuration / 2f);
        }

        public IEnumerator Hide()
        {
            yield return Utils.RotateTo(transform, Quaternion.Euler(0f, 90f, 0f), flipDuration / 2f);
            icon.color = Color.clear;
            yield return Utils.RotateTo(transform, Quaternion.Euler(0f, 0f, 0f), flipDuration / 2f);
        }
    }
}
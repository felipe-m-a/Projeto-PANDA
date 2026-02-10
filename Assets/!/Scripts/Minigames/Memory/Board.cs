using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Panda.Minigames.Memory
{
    [RequireComponent(typeof(FlexibleGridLayoutGroup))]
    [RequireComponent(typeof(AspectRatioFitter))]
    [RequireComponent(typeof(CanvasGroup))]
    public class Board : MonoBehaviour
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private Sprite[] sprites;

        private FlexibleGridLayoutGroup _gridLayoutGroup;
        private AspectRatioFitter _aspectRatioFitter;
        private CanvasGroup _canvasGroup;

        private Card _selectedCard;
        private Minigame _minigame;

        public bool IsInteractable
        {
            get => _canvasGroup.interactable;
            set => _canvasGroup.interactable = value;
        }

        public void Initialize(Minigame minigame)
        {
            _minigame = minigame;
            SetSize(_minigame.Rows, _minigame.Columns);
            SpawnCards();
            IsInteractable = true;
        }

        public IEnumerator SelectCard(Card card)
        {
            IsInteractable = false;
            card.IsInteractable = false;

            yield return card.Show();
            if (_selectedCard is null)
            {
                _selectedCard = card;
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
                yield return CheckMatch(card);
            }

            IsInteractable = true;
        }

        private IEnumerator CheckMatch(Card card)
        {
            if (_selectedCard.Matches(card))
            {
                _minigame.AddMatch();
            }
            else
            {
                _selectedCard.IsInteractable = true;
                card.IsInteractable = true;
                StartCoroutine(card.Hide());
                yield return _selectedCard.Hide();
            }

            _selectedCard = null;
        }

        private void SpawnCards()
        {
            var selectedSprites = Utils.PickRandom(sprites, _minigame.Pairs);

            foreach (var id in _minigame.Symbols)
            {
                var card = Instantiate(cardPrefab, transform);
                var sprite = selectedSprites[id];
                card.Initialize(sprite, this);
            }
        }

        private void SetSize(int rows, int columns)
        {
            _gridLayoutGroup.rows = rows;
            _gridLayoutGroup.columns = columns;
            _aspectRatioFitter.aspectRatio = columns / (float)rows;
        }

        private void Awake()
        {
            _gridLayoutGroup = GetComponent<FlexibleGridLayoutGroup>();
            _aspectRatioFitter = GetComponent<AspectRatioFitter>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}
using System;
using UnityEngine;
using Random = System.Random;

namespace _Source.Game
{
    public class CardLayout : MonoBehaviour
    {
        public GameObject cardGameObject;
        private CardGame _cardGame;
        public int layoutId;
        public Vector2 offset;
        public bool faceUp;
        public Sprite cardBack;
        public int capacity;

        private void Awake()
        {
            _cardGame = cardGameObject.GetComponent<CardGame>();
            if (cardGameObject == null) {
                throw new Exception("CardLayout: cardGameObject is not set");
            } else {
                _cardGame.layoutToCardCount.Add(layoutId, 0);
            }
        }

        private void Update()
        {
            foreach (CardInstance card in _cardGame.GetCardsInLayout(layoutId)) {
                var cardView = _cardGame.instanceToView[card];
                cardView.cardBack = cardBack;
                cardView.transform.SetParent(transform);
                cardView.transform.localPosition = new Vector3(
                    offset.x * card.cardPosition, 
                    offset.y * card.cardPosition, 
                    capacity - card.cardPosition);
                cardView.Rotate(faceUp);
            }
        }
        
        public void ShuffleLayout()
        {
            var cards = _cardGame.GetCardsInLayout(layoutId);
            for (int i = 0; i < cards.Count; i++)
            {
                int temp = cards[i].cardPosition;
                int randomIndex = UnityEngine.Random.Range(i, cards.Count);
                cards[i].cardPosition = cards[randomIndex].cardPosition;
                cards[randomIndex].cardPosition = temp;
            }
            _cardGame.RecalculateLayout(layoutId);
        }
    }
}

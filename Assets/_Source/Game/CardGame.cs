using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.Game
{
    public class CardGame : MonoBehaviour
    {
        public GameObject player1, player2;
        public GameObject cardPrefab;
        public int player1DeckLayout, player2DeckLayout, player1HandLayout, player2HandLayout, playAreaLayout;
        
        public Dictionary<CardInstance, CardView> instanceToView = new Dictionary<CardInstance, CardView>();
        public Dictionary<int, int> layoutToCardCount = new Dictionary<int, int>();
        public List<CardAsset> starterCards = new List<CardAsset>();
        public int handCapacity = 3;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            foreach (var cardAsset in starterCards)
            {
                CreateCard(cardAsset, player1DeckLayout);
                CreateCard(cardAsset, player2DeckLayout);
            }
            StartTurn();
        }
        
        public void CreateCardView(CardInstance cardInstance)
        {
            var cardObject = Instantiate(cardPrefab);
            var cardView = cardObject.GetComponent<CardView>();
            cardView.Init(cardInstance);
            instanceToView[cardInstance] = cardView;
        }
        
        public void CreateCard(CardAsset cardAsset, int layoutId)
        {
            var cardInstance = new CardInstance(cardAsset, this);
            instanceToView.Add(cardInstance, null);
            CreateCardView(cardInstance);
            cardInstance.MoveToLayout(layoutId);
        }
        
        public List<CardInstance> GetCardsInLayout(int layoutId)
        {
            var cards = new List<CardInstance>();
            foreach (var cardInstance in instanceToView.Keys)
            {
                if (cardInstance.layoutId == layoutId)
                {
                    cards.Add(cardInstance);
                }
            }
            return cards;
        }
        
        public void RecalculateLayout(int layoutId)
        {
            var cards = GetCardsInLayout(layoutId);
            cards.Sort((a, b) => a.cardPosition.CompareTo(b.cardPosition));
            for (var i = 0; i < cards.Count; i++)
            {
                cards[i].cardPosition = i;
            }
        }
        
        public void StartTurn()
        {
          for (int i = 0; i < handCapacity; i++) { 
              TryMoveCard(player1DeckLayout, player1HandLayout); 
              TryMoveCard(player2DeckLayout, player2HandLayout);
          }
        }
        
        public void TryMoveCard(int fromLayoutId, int toLayoutId)
        {
            var cards = GetCardsInLayout(fromLayoutId);
            if (cards.Count > 0)
            {
                cards[cards.Count - 1].MoveToLayout(toLayoutId);
            }
        }
    }
}

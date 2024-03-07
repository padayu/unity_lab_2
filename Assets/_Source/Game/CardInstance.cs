using UnityEngine;

namespace _Source.Game
{
    public class CardInstance
    {
        public CardAsset cardAsset;
        public string cardName;
        public Color cardColor;
        public Sprite cardImage;
        
        public int layoutId;
        public int cardPosition;
        
        public CardGame cardGame;
    
        public CardInstance(CardAsset cardAsset, CardGame cardGame)
        {
            this.cardAsset = cardAsset;
            cardName = cardAsset.cardName;
            cardColor = cardAsset.cardColor;
            cardImage = cardAsset.cardImage;
            this.cardGame = cardGame;
        }

        
        public void MoveToLayout(int layoutId)
        {
            int oldLayoutId = this.layoutId;
            cardGame.layoutToCardCount[this.layoutId]--;
            this.layoutId = layoutId;
            cardGame.layoutToCardCount[layoutId]++;
            this.cardPosition = cardGame.layoutToCardCount[layoutId];
            cardGame.RecalculateLayout(oldLayoutId);
            cardGame.RecalculateLayout(this.layoutId);
        }
    }
}

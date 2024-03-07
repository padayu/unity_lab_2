using UnityEngine;

namespace _Source.Game
{
    public class CardView : MonoBehaviour
    {
        public CardInstance cardInstance;
        public Sprite cardBack;
        private SpriteRenderer _spriteRenderer;
        
        public void Init(CardInstance cardInstance)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            this.cardInstance = cardInstance;
            gameObject.name = cardInstance.cardName;
            _spriteRenderer.color = cardInstance.cardColor;
            _spriteRenderer.sprite = cardInstance.cardImage;
        }

        public void Rotate(bool up)
        {
            if (up) {
                _spriteRenderer.sprite = cardInstance.cardImage;
                _spriteRenderer.color = cardInstance.cardColor;
            } else {
                _spriteRenderer.sprite = cardBack;
                _spriteRenderer.color = Color.white;
            }
        }
        
        public void PlayCard()
        {
            cardInstance.MoveToLayout(cardInstance.cardGame.playAreaLayout);
        }
    }
}

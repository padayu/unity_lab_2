using UnityEngine;

namespace _Source.Game
{
    [CreateAssetMenu(fileName = "New CardAsset", menuName = "Card Asset", order = 51)]
    public class CardAsset : ScriptableObject
    {
        public string cardName;
        public Color cardColor;
        public Sprite cardImage;
    }
}

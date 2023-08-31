using UnityEngine;

namespace Code
{
    public class ColorCollision : MonoBehaviour
    {
        [SerializeField] private ShapeColor _shapeColor;
        
        private GameHandler _gameHandler;

        public void Construct(GameHandler gameHandler)
        {
            _gameHandler = gameHandler;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ShapeColor otherColor) == false) return;

            if (_shapeColor.Color != otherColor.Color)
            {
                _gameHandler.Lose();
            }
        }
    }
}
using UnityEngine;

namespace Code
{
    public class ColorCollision : MonoBehaviour
    {
        [SerializeField] private ShapeColor _shapeColor;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ShapeColor otherColor) == false) return;
            if (otherColor.Color == Color.Wild || _shapeColor.Color == Color.Wild) return;

            if (_shapeColor.Color != otherColor.Color)
            {
                // TODO: Lose Game
                Debug.Log("Lose");
            }
        }
    }
}
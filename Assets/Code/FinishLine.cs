using UnityEngine;

namespace Code
{
    public class FinishLine : MonoBehaviour
    {
        private GameHandler _gameHandler;

        public void Construct(GameHandler gameHandler)
        {
            _gameHandler = gameHandler;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ColorCollision _))
                _gameHandler.Win();
        }
    }
}
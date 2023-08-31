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
            if (other.TryGetComponent(out JumpHandler jumpHandler) == false) return;
            if (jumpHandler.TryGetComponent(out Rigidbody2D rb) == false) return;

            jumpHandler.enabled = false;
            rb.simulated = false;
            
            _gameHandler.Win();
        }
    }
}
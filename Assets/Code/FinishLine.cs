using UnityEngine;

namespace Code
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            // TODO: Win Game
            Debug.Log("Win");
        }
    }
}
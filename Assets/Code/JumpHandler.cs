using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpHandler : MonoBehaviour
    {
        [SerializeField] private float _jumpVelocity;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.simulated = false;
        }

        private void Update()
        {
            if (Input.anyKeyDown || Input.touchCount > 0)
            {
                _rigidbody.simulated = true;
                Jump();
            }
        }

        private void Jump()
        {
            _rigidbody.velocity = Vector2.up * _jumpVelocity;
        }
    }
}
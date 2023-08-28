using UnityEngine;

namespace Code
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.Rotate(0f, 0f, _speed * Time.deltaTime);
        }
    }
}